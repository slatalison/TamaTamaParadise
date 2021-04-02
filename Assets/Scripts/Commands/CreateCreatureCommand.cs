using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCreatureCommand : Command {
    private Vector3 location;
    private Breed breed;
    private Team team;

    public CreateCreatureCommand(Vector3 _location, Breed _breed, Team _team = Team.Neutral) {
        this.location = _location;
        this.breed = _breed;
        this.team = _team;
    }

    public override void StartCommandExecution() {
        GameObject newMob = GameObject.Instantiate(Resources.Load("TamasPrefab/Mob"), location, Quaternion.identity) as GameObject;
        // put all mobs in petri dish
        newMob.transform.parent = GameObject.Find("PetriDishSelf").transform;
        Mob mob = newMob.GetComponent<Mob>();
        mob.mobID = IDDispenser.RegisterObject(newMob);
        mob.info = breed.NewMobInfo();
        mob.team = team;
        newMob.name = mob.info.breed.breedName + "-" + mob.mobID;

        ContainerEnv env = GameObject.Find("Canvas/EnvConfigPanel/ClipBinder").GetComponent<ContainerEnv>() as ContainerEnv;
        mob.EnvironmentChanged(env.CurrentTemp, env.CurrentPres);

        CommandExecutionComplete();
    }
}
