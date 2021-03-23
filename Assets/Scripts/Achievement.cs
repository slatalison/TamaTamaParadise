using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Achievement {

    public static Dictionary<int, Achievement> allAchievements = new Dictionary<int, Achievement>();

    public int id;
    public string name;
    public Sprite icon;
    public string description;

    public int repeatTime;
    public float timeLimit;

    private Dictionary<float, int> currentAccumulation;
    private float currentTime;

    public Achievement() {
        id = -1;
        name = "Undefined";
        icon = null;
        description = "Undefined";
        repeatTime = 1;
        timeLimit = -1;

        currentAccumulation = new Dictionary<float, int>();
        currentTime = 0;
        allAchievements[this.id] = this;
    }

    public Achievement(int _id, string _name, Sprite _icon, string _description, int _repeatTime, int _timeLimit) {
        id = _id;
        name = _name;
        icon = _icon;
        description = _description;
        repeatTime = _repeatTime;
        timeLimit = _timeLimit;

        currentAccumulation = new Dictionary<float, int>();
        currentTime = 0;
        allAchievements[this.id] = this;
    }

    public void Unlock() {
        currentTime = Time.time;

        if (timeLimit > 0) { // which means there's some time limit
            currentAccumulation[currentTime] = 1;

            foreach (var timeStamp in currentAccumulation.Keys.ToList()) {
                if (timeStamp + timeLimit < currentTime) {
                    // Delete records that out of the time scope
                    currentAccumulation.Remove(timeStamp);
                    continue;
                } else {
                    // Accumulate for others
                    currentAccumulation[timeStamp] += 1;
                }

                if (currentAccumulation[timeStamp] > repeatTime) {
                    OnUnlock();
                }
            }
        } else { // which means no time limit
            if (currentAccumulation.ContainsKey(currentTime) == false) {
                currentAccumulation[currentTime] = 1;    
            } 

            float onlyTimeStamp = currentAccumulation.Keys.ToList()[0];
            currentAccumulation[onlyTimeStamp] += 1;
            if (currentAccumulation[onlyTimeStamp] > repeatTime) {
                OnUnlock();
            }
        }
    }

    private void OnUnlock() {
        Debug.Log("Unlocked " + name + ".");
        // UI.showUnlock(XXX);
    }
}