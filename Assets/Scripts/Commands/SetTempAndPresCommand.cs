using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTempAndPresCommand : Command {

    private float temp;
    private float pres;
    private string name;

    public SetTempAndPresCommand(float _temp, float _pres, string _name) {
        this.temp = _temp;
        this.pres = _pres;
        this.name = _name;
    }

    public override void StartCommandExecution() {
        ContainerEnv env = GameObject.Find("_GameCanvas/_Tabs/_ConfigTab").GetComponent<ContainerEnv>() as ContainerEnv;
        env.SetTempAndPres(this.temp, this.pres, this.name);

        CommandExecutionComplete();

        // condition:
        // temp = 100
        // pres = 100

        // id: 100

        // int id = 100;
        // if (temp == 100 && pres = 100) {
        //     Achievement.allAchievements[id].Unlock();
        // }
    }
}
