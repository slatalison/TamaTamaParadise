using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : MonoBehaviour {

    private Mob parentMob;
    
    void Start() {
        parentMob = GetComponentInParent<Mob>() as Mob;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "bullet") {
            Bullet b = other.gameObject.GetComponent<Bullet>() as Bullet;
            if (b != null && b.target == parentMob.gameObject) {
                parentMob.TakeDamage(b.damage);
                Destroy(other.gameObject);
            }
        }
    }
}
