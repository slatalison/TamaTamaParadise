using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuffInfo {

    public string buff_name;

    public int buff_max_hp;
    public int buff_curr_hp;
    public int buff_atk;
    public float buff_atk_radius;
    public float buff_atk_threshold;
    public int buff_attract;
    public int buff_food_power;
    public int buff_zombies;

}

[System.Serializable]
public class Buff {

    public virtual void Attach() {

    }

    public virtual void Remove() {

    }
}
