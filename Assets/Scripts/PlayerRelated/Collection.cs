using System.Collections.Generic;
using UnityEngine;

public static class Collection {
    public static HashSet<int> eventUnlockedID = new HashSet<int>();
    public static HashSet<int> redBreedUnlockedID = new HashSet<int>();
    public static HashSet<int> blueBreedUnlockedID = new HashSet<int>();

    public static void UnlockEvent(int ID) {

        if (Achievement.allAchievements.ContainsKey(ID) == true)
        {
        if (eventUnlockedID.Contains(ID)) {
            return;
        }
        eventUnlockedID.Add(ID);
        Debug.Log("Achieved: " + Achievement.allAchievements[ID].name);
        }
    }

    public static void UnlockRedBreed(int ID) {
        if (Breed.breedCollection.ContainsKey(ID) == true)
        {
            if (redBreedUnlockedID.Contains(ID))
            {
                return;
            }
            redBreedUnlockedID.Add(ID);
            Debug.Log("Found: Red " + Breed.breedCollection[ID].breedName);
        }
    }

    public static void UnlockBlueBreed(int ID)
    {

        if (Breed.breedCollection.ContainsKey(ID) == true)
        {
            if (blueBreedUnlockedID.Contains(ID))
            {
                return;
            }
            blueBreedUnlockedID.Add(ID);
            Debug.Log("Found: Blue " + Breed.breedCollection[ID].breedName);
        }
    }
}