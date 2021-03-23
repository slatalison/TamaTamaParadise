using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : Command {
    private int attacker_id;
    private int target_id;
    private int damage;

    public AttackCommand(int _attacker_id, int _target_id, int _damage) {
        this.attacker_id = _attacker_id;
        this.target_id = _target_id;
        this.damage = _damage;
    }

    public override void StartCommandExecution() {
        GameObject attacker = IDDispenser.GetGameObjectWithID(attacker_id);
        GameObject target = IDDispenser.GetGameObjectWithID(target_id);
        if (attacker != null && target != null) {
            GameObject bullet = GameObject.Instantiate(Resources.Load("Bullet"),
                                                       attacker.transform.position,
                                                       attacker.transform.rotation) as GameObject;
            bullet.GetComponent<Bullet>().target = target;
            bullet.GetComponent<Bullet>().damage = attacker.GetComponent<Mob>().info.atk;
        }

        CommandExecutionComplete();
    }
}
