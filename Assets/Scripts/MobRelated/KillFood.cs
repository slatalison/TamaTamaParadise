using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFood : MonoBehaviour
{

    public static FundManager fm = null;
    public static LevelManager lm = null;
    private AudioSource _audio;
    public AudioClip collectSound;


    // Start is called before the first frame update
    void Start()
    {
        _audio = gameObject.GetComponent<AudioSource>();

        if (fm == null)
        {
            fm = GameObject.Find("_GameCanvas/_TopBar/_FundBackdrop/_fundValue").GetComponent<FundManager>();
        }

        if (lm == null)
        {
            lm = GameObject.Find("_GameCanvas/_TopBar/_LevelBackdrop/_LevelNum").GetComponent<LevelManager>();
        }
    }


    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("food")){
            Food food = other.GetComponent<Food>();
            if (food == null) 
            {
                return;
            }
            fm.Increase(food.healingValue);
            lm.PlayerExpGrow(food.healingValue);
            _audio.PlayOneShot(collectSound);
            Destroy(other.gameObject);
        } else if (other.CompareTag("bullet"))
        {
            Attacker bullet = other.GetComponent<Attacker>();
            if (bullet == null)
            {
                return;
            }
            fm.Increase(bullet.parentMob.info.atk);
            lm.PlayerExpGrow(bullet.parentMob.info.atk);
            Destroy(other.gameObject);
        }
    }

}


