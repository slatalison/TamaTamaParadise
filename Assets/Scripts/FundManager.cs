using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FundManager : MonoBehaviour {

    public TextMeshProUGUI numberArea;
    public double number = 0;

    void Start() {
        numberArea.SetText("0".PadLeft(0, ' '));
    }

    public void Increase(int amount) {
        number += amount;
        numberArea.SetText(number.ToString().PadLeft(0, ' '));
    }

    public void Decrease(int amount) {
        number -= amount;
        numberArea.SetText(number.ToString().PadLeft(0, ' '));
    }
}
