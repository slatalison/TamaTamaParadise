using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
    public float vanishingTime;
    public float movingSpeed;
    public int healingValue;

    public float cooldownTime;
    public bool eatable = false;

    public Team team;

    public static FundManager fm = null;

    private List<Mob> eaters;

    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start() {

        if (fm == null) {
            fm = GameObject.Find("Canvas/TopBar/FundBackdrop/fundValue").GetComponent<FundManager>();
        }

        StartCoroutine(Cooldown());
        if (movingSpeed <= 0.01f) {
            movingSpeed = 0.01f;
        }
        rig = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rig.AddForce(Random.insideUnitCircle * movingSpeed);

        eaters = new List<Mob>();
        Destroy(gameObject, vanishingTime);
    }

    // Update is called once per frame
    void Update() {
        if (eaters.Count > 0) {
            int eaterIndex = Random.Range(0, eaters.Count - 1);
            Debug.DrawLine(eaters[eaterIndex].transform.localPosition, this.transform.localPosition,
                           Color.white, duration: 0.05f);
            eaters[eaterIndex].Heal(healingValue, team);
            Destroy(gameObject);
        }
    }

    void OnMouseEnter() {
        fm.Increase(healingValue);
        Destroy(gameObject);
    }

    public void WantToEat(Mob mob) {
        if (eatable == true) {
            eaters.Add(mob);   
        }
    }

    IEnumerator Cooldown() {
        yield return new WaitForSeconds(cooldownTime);
        eatable = true;
        yield return 0;
    }
}
