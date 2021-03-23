using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTempAndPresCommand : Command {

    private float temp;
    private float pres;

    public SetTempAndPresCommand(float _temp, float _pres) {
        this.temp = _temp;
        this.pres = _pres;
    }

    public override void StartCommandExecution() {
        ContainerEnv env = GameObject.Find("Canvas/EnvButtonPanel/EnvButton").GetComponent<ContainerEnv>() as ContainerEnv;
        env.SetTempAndPres(this.temp, this.pres);

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
