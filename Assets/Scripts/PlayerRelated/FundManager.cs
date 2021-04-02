using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FundManager : MonoBehaviour {

    public TextMeshProUGUI numberArea;
    public double foodCount = 0;

    void Start() {
        numberArea.SetText("0");
    }

    public void Increase(int amount) {
        foodCount += amount;
        numberArea.SetText(foodCount.ToString());
    }

    public void Decrease(int amount) {
        foodCount -= amount;
        numberArea.SetText(foodCount.ToString());
    }
}
