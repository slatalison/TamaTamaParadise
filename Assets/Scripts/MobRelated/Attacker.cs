using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
    public int targetID;
    public float attackFrequency;

    public Mob parentMob;
    private CircleCollider2D col;

    private Coroutine attackTimer;

    void Start() {
        targetID = -1; // -1 means no target
        parentMob = GetComponentInParent<Mob>() as Mob;
        if (attackFrequency < 1) {
            attackFrequency = 1;
        }
        attackTimer = null;
        col = gameObject.GetComponent<CircleCollider2D>() as CircleCollider2D;
        col.radius = parentMob.info.atkRadius;

        parentMob.res += Restart;
    }

    void OnDestroy() {
        parentMob.res -= Restart;
    }

    void OnDisable() {
        targetID = -1;
        if (attackTimer != null) {
            StopCoroutine(attackTimer);
            attackTimer = null;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "damageTaker" && (int) parentMob.team > 0) {
            if (targetID == -1) {
                Mob otherMob = other.gameObject.GetComponentInParent<Mob>();
                if ((int) otherMob.team > 0 && parentMob.team != otherMob.team) {
                    targetID = otherMob.mobID;
                    attackTimer = StartCoroutine(AttackMob());
                }
            } else if (!IDDispenser.ContainsID(targetID)) {
                targetID = -1;
            }
        }
    }

    IEnumerator AttackMob() {
        while (IDDispenser.ContainsID(targetID)) {
            yield return new WaitForSeconds(60f / attackFrequency);
            new AttackCommand(parentMob.mobID, targetID, parentMob.info.atk).AddToQueue();
        }
    }

    public void Restart() {
        if (gameObject.active == false) {
            return;
        }

        //Debug.Log(parentMob);
        col.radius = parentMob.info.atkRadius;

        targetID = -1;
        if (attackTimer != null) {
            StopCoroutine(attackTimer);
            attackTimer = null;
        }
    }
}
