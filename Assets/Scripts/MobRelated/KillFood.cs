using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFood : MonoBehaviour
{

    public static FundManager fm = null;
    public static LevelManager lm = null;


    // Start is called before the first frame update
    void Start()
    {
        if (fm == null)
        {
            fm = GameObject.Find("Canvas/TopBar/FundBackdrop/fundValue").GetComponent<FundManager>();
        }

        if (lm == null)
        {
            lm = GameObject.Find("Canvas/TopBar/LevelBackdrop/LevelNum").GetComponent<LevelManager>();
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
            Destroy(other.gameObject);
        }
    }

}


