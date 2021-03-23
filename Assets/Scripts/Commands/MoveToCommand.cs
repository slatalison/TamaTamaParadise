using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveToCommand : Command {

    private int object_ID;
    private Vector3 target_position;
    private float time_cost;

    public MoveToCommand(int _object_ID, Vector3 _target_position, float _time_cost) {
        this.object_ID = _object_ID;
        this.target_position = _target_position;
        this.time_cost = _time_cost;
    }

    public override void StartCommandExecution() {
        IDDispenser.GetGameObjectWithID(object_ID).transform.DOMove(this.target_position, this.time_cost);

        CommandExecutionComplete();
    }
}
