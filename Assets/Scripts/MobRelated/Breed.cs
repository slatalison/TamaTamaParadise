using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Breed {
    
    public static Dictionary<int, Breed> breedCollection = new Dictionary<int, Breed>(); 

    public string breedName;
    public int breedID;
    public int parentID;
    [SerializeField] private Breed parent;

    [SerializeField] private int maxHp;
    [SerializeField] private int atk;
    [SerializeField] private float atkRadius;
    [SerializeField] private float atkThreshold;
    [SerializeField] private int attract;
    [SerializeField] private float foodPower;
    [SerializeField] private int zombies;

    [SerializeField] private AnimationCurve tempFoodCurve;
    [SerializeField] private AnimationCurve presFoodCurve;
    [SerializeField] private AnimationCurve tempAtkCurve;
    [SerializeField] private AnimationCurve presAtkCurve;

    public Breed(string _name, int _breedID, int _parentID, int _maxHp, int _atk, float _atkRadius,
                 float _atkThreshold, int _attract, float _foodPower, int _zombies, AnimationCurve _tempFoodCurve,
                 AnimationCurve _presFoodCurve, AnimationCurve _tempAtkCurve, AnimationCurve _presAtkCurve) {
        this.breedName = _name;
        this.breedID = _breedID;
        this.parentID = _parentID;

        if (breedCollection.ContainsKey(_parentID)) {
            this.parent = breedCollection[_parentID];    
        } else {
            this.parent = null;
        }
        
        this.maxHp = _maxHp;
        this.atk = _atk;
        this.atkRadius = _atkRadius;
        this.atkThreshold = _atkThreshold;
        this.attract = _attract;
        this.foodPower = _foodPower;
        this.zombies = _zombies;
        this.tempFoodCurve = _tempFoodCurve;
        this.presFoodCurve = _presFoodCurve;
        this.tempAtkCurve = _tempAtkCurve;
        this.presAtkCurve = _presAtkCurve;

        if (parent != null) {
            if (this.maxHp == -1) {
                this.maxHp = parent.GetMaxHp();
            }
            if (this.atk == -1) {
                this.atk = parent.GetAtk();
            }
            if (this.attract == -1) {
                this.attract = parent.GetAttract();
            }
            if (this.foodPower == -1) {
                this.foodPower = parent.GetFoodPower();
            }
            if (this.zombies == -1) {
                this.zombies = parent.GetZombies();
            }
        }

        breedCollection.Add(this.breedID, this);
    }

    public int GetMaxHp() {
        return this.maxHp;
    }

    public int GetAtk() {
        return this.atk;
    }

    public float GetAtkRadius() {
        return this.atkRadius;
    }

    public float GetAtkThreshold() {
        return this.atkThreshold;
    }

    public int GetAttract() {
        return this.attract;
    }

    public float GetFoodPower() {
        return this.foodPower;
    }

    public int GetZombies() {
        return this.zombies;
    }

    public AnimationCurve GetTempFoodCurve() {
        return this.tempFoodCurve;
    }
    public AnimationCurve GetPresFoodCurve() {
        return this.presFoodCurve;
    }
    public AnimationCurve GetTempAtkCurve() {
        return this.tempAtkCurve;
    }
    public AnimationCurve GetPresAtkCurve() {
        return this.presAtkCurve;
    }

    public MobInfo NewMobInfo() {
        return new MobInfo(this);
    }
}
