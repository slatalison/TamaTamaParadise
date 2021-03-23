using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDetector : MonoBehaviour
{

    private Mob parentMob;
    
    void Start() {
        parentMob = GetComponentInParent<Mob>() as Mob;
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "food") {
            Food food = other.gameObject.GetComponent<Food>() as Food;
            if (food != null) {
                if (parentMob.info.currHp < parentMob.info.maxHp && parentMob.team == food.team) {
                    food.WantToEat(parentMob);
                }
                if (parentMob.team == Team.Neutral) {
                    food.WantToEat(parentMob);
                }
            }
        }
    }
}
