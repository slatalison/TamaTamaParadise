using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour {

    public int mobID;
    public MobInfo info;

    private Coroutine foodTimer;
    private bool dead;
    [SerializeField] private GameObject attacker;
    private DragController dragController; 

    [SerializeField, SetProperty("team")]
    private Team _team;
    public Team team {
        get { return _team; }
        set {
            _team = value;
            switch (value) {
                case Team.Neutral:
                    info.ClearProperties();
                    Restart();
                    gameObject.GetComponent<SpriteRenderer>().sprite = MobInfo.neutralTexture;
                    break;
                case Team.Red:
                    Collection.UnlockRedBreed(info.breed.breedID);
                    info.RestoreProperties();
                    Restart();
                    gameObject.GetComponent<SpriteRenderer>().sprite = MobInfo.redTexture;
                    break;
                case Team.Blue:
                    Collection.UnlockBlueBreed(info.breed.breedID);
                    info.RestoreProperties();
                    Restart();
                    gameObject.GetComponent<SpriteRenderer>().sprite = MobInfo.blueTexture;
                    break;
                default:
                    break;
            }
        }
    }

    public delegate void RestartUpdate();
    public RestartUpdate res;

    void Start() {
        dead = false;
        if (info.foodPower > 0) {
            foodTimer = StartCoroutine(ProduceFood(info.foodPower));
        }
        attacker = gameObject.transform.Find("Attacker").gameObject;
        ContainerEnv.tempPresChange += EnvironmentChanged;

        // for test perpose
        new MoveToCommand(mobID, new Vector3(Random.Range(-1.9f, 1.9f), Random.Range(-2.9f, 3.4f), 0), Random.Range(1.0f, 3.0f)).AddToQueue();

        dragController = FindObjectOfType<DragController>();
    }

    IEnumerator ProduceFood(float foodPower) {
        while (true) {
            yield return new WaitForSeconds(60f / foodPower);
            GameObject food = GameObject.Instantiate(Resources.Load("TamasPrefab/Food"),
                                                     this.transform.position,
                                                     this.transform.rotation) as GameObject;
            food.transform.parent = GameObject.Find("PetriDishSelf").transform;
            food.GetComponent<Food>().team = team;
        }
    }

    public void TakeDamage(int value) {
        info.currHp -= value;
        //掉血的时候降低贴图透明度
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (float)info.currHp / info.maxHp);
        Debug.Log((float)info.currHp / info.maxHp);
        if (info.currHp <= 0 && dead == false) {
            dead = true;
            Die();
        }
    }

    public void Heal(int value, Team _team) {
        if (info.currHp < info.maxHp) {
            info.currHp += value;
            //加血的时候增加贴图透明度
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (float)info.currHp/info.maxHp);
        }
        info.currHp = info.currHp < info.maxHp ? info.currHp : info.maxHp;
        if (team == Team.Neutral) {
            switch(_team) {
                case Team.Red:
                    info.redFoodCount += 1;
                    if (info.redFoodCount >= 10) {
                        team = _team;
                    }
                    break;
                case Team.Blue:
                    info.blueFoodCount += 1;
                    if (info.blueFoodCount >= 10) {
                        team = _team;
                    }
                    break;
                default:
                    break;
            }
        }
    }

    private void Die() {
        // Debug.Log(gameObject.name + " has died.");

        dragController._lastDragged = null;
        Destroy(gameObject.GetComponent<Draggable>());
        

        IDDispenser.UnregisterObject(mobID);
        ContainerEnv.tempPresChange -= EnvironmentChanged;

        gameObject.GetComponent<SpriteRenderer>().sprite = MobInfo.deadTexture;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

        Collection.UnlockEvent(1);

        // TODO: Change texture
        info.ClearProperties();
        Restart();
    }

    public void OnMouseDown() {
        if (!dead) {
            return;
        }
        Collection.UnlockEvent(3);
        Destroy(gameObject);
    }

    public void EnvironmentChanged(float temp, float pres) {
        info.foodPower = (int) (info.tempFoodCurve.Evaluate(temp) + info.presFoodCurve.Evaluate(pres));
        attacker.GetComponent<Attacker>().attackFrequency = (int) (info.tempAtkCurve.Evaluate(temp) + info.presAtkCurve.Evaluate(pres));
        // Debug.Log(gameObject.name + " noteiced temperature is now: " + temp + " and pressure has changed to: " + pres);
        if (temp > info.atkThreshold) {
            attacker.SetActive(true);
        } else {
            attacker.SetActive(false);
        }
        Restart();
    }

    private void Restart() {
        StopAllCoroutines();
        foodTimer = StartCoroutine(ProduceFood(info.foodPower));
        if (res != null) {
            res();
        }
        StartCoroutine(RestartAttackerLater());
    }

    IEnumerator RestartAttackerLater() {
        yield return new WaitForSeconds(0.001f);
        if (attacker.active == true) {
            attacker.GetComponent<Attacker>().Restart();    
        }
    }
}
