using UnityEngine;

[System.Serializable]
public class MobInfo {
    public static Sprite redTexture = Resources.Load<Sprite>("TamasPrefab/TamaR");
    public static Sprite blueTexture = Resources.Load<Sprite>("TamasPrefab/TamaB");
    public static Sprite neutralTexture = Resources.Load<Sprite>("NeutralMob");
    public static Sprite deadTexture = Resources.Load<Sprite>("TamasPrefab/TamaDead");

    public Breed breed;
    
    public int maxHp;
    public int currHp;
    public int atk;
    public float atkRadius;
    public float atkThreshold;
    public int attract;
    public float foodPower;
    public int zombies;

    public int redFoodCount;
    public int blueFoodCount;

    public AnimationCurve tempFoodCurve;
    public AnimationCurve presFoodCurve;
    public AnimationCurve tempAtkCurve;
    public AnimationCurve presAtkCurve;

    public MobInfo(Breed _breed) {
        this.breed = _breed;
        ClearProperties();
    }

    public void ClearProperties() {
        this.maxHp = 0;
        this.currHp = 0;
        this.atk = 0;
        this.atkRadius = 0;
        this.atkThreshold = 0;
        this.attract = 0;
        this.foodPower = 0;
        this.zombies = 0;
        this.redFoodCount = 0;
        this.blueFoodCount = 0;
    }

    public void RestoreProperties() {
        this.maxHp = this.breed.GetMaxHp();
        this.currHp = this.breed.GetMaxHp();
        this.atk = this.breed.GetAtk();
        this.atkRadius = this.breed.GetAtkRadius();
        this.atkThreshold = this.breed.GetAtkThreshold();
        this.attract = this.breed.GetAttract();
        this.foodPower = this.breed.GetFoodPower();
        this.zombies = this.breed.GetZombies();
        this.tempFoodCurve = this.breed.GetTempFoodCurve();
        this.presFoodCurve = this.breed.GetPresFoodCurve();
        this.tempAtkCurve = this.breed.GetTempAtkCurve();
        this.presAtkCurve = this.breed.GetPresAtkCurve();
    }
}
