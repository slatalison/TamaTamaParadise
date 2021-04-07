using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopulationManager : MonoBehaviour {
    public int populationUpperBound;
    public int currentPopulation;

    public float spwanAreaXMax;
    public float spwanAreaXMin;
    public float spwanAreaYMax;
    public float spwanAreaYMin;

    public float mobSpawnTimeIntervalMax;
    public float mobSpawnTimeIntervalMin;

    private float nextTry;
    private Coroutine timer;

    [SerializeField] TextMeshProUGUI currentTotalText;

    // Start is called before the first frame update
    void Start() {
        if (mobSpawnTimeIntervalMin > mobSpawnTimeIntervalMax) {
            mobSpawnTimeIntervalMax = mobSpawnTimeIntervalMin;
        }
        nextTry = Random.Range(mobSpawnTimeIntervalMin, mobSpawnTimeIntervalMax);
        timer = StartCoroutine(Timer());
    }

    public void RegisterObject(GameObject go) {
        currentPopulation += 1;
        SetPopulationNumber();
    }

    public void UnregisterObject(GameObject go) {
        currentPopulation -= 1;
        SetPopulationNumber();
    }

    public void SetPopulationNumber()
    {
        currentTotalText.SetText(currentPopulation.ToString());
    }

    IEnumerator Timer() {
        while (true) {
            yield return new WaitForSeconds(nextTry);
            nextTry = Random.Range(mobSpawnTimeIntervalMin, mobSpawnTimeIntervalMax);
            Vector3 location = new Vector3(Random.Range(spwanAreaXMin, spwanAreaXMax),
                                           Random.Range(spwanAreaYMin, spwanAreaYMax), 0);
            if (currentPopulation < populationUpperBound) {

                // Randomly select a breed
                int randomNumber = Random.Range(1, Breed.breedCollection.Count + 1);
                Breed breed = Breed.breedCollection[randomNumber];

                if (location != null) {
                    new CreateCreatureCommand(location, breed, Team.Neutral).AddToQueue();       
                }
            }
        }
    }
}
