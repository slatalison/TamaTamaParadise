using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public bool InitTamaSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        Breed br;
        string jsonString = "{}";
        foreach (string path in Directory.GetFiles("./Assets/Resources/Breed"))
        {
            if (Path.GetExtension(path) == ".json")
            {
                jsonString = File.ReadAllText(path);
                br = JsonUtility.FromJson<Breed>(jsonString);
                Breed.breedCollection[br.breedID] = br;
            }
        }

        //此处照抄 load achievement
        //Achievement.allAchievements

        Achievement ach;
        string achJsonString = "{}";
        foreach (string path in Directory.GetFiles("./Assets/Resources/Achievement"))
        {
            if (Path.GetExtension(path) == ".json")
            {
                achJsonString = File.ReadAllText(path);
                ach = JsonUtility.FromJson<Achievement>(achJsonString);
                Achievement.allAchievements[ach.id] = ach;
            }
        }

        // CollectionDetail(int _id, Sprite _icon, string _name, string _description)
        // new CollectionDetail(1, null, "Passed away", "A mob is beaten to death.");
        // new CollectionDetail(3, null, "Astronomia", "Ghana's dancing pallbearers.");
    }

    // Update is called once per frame
    void Update()
    {
        if (InitTamaSpawn == true)
        {
            InitTamaSpawn = false;
            for (int i = 0; i < 10; i++)
            {
                Vector3 location = new Vector3(Random.Range(-1.95f, 1.95f),
                                       Random.Range(-2.9f, 3.4f), 0);
                int random_number = Random.Range(1, Breed.breedCollection.Count + 1);
                Breed breed = Breed.breedCollection[random_number];
                new CreateCreatureCommand(location, breed, (Team)(i % 2) + 1).AddToQueue();
            }
        }
    }
}
