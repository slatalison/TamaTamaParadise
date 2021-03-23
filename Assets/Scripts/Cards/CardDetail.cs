using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardDetail : MonoBehaviour {

    public TextMeshProUGUI detail_name;
    public TextMeshProUGUI detail_press;
    public TextMeshProUGUI detail_temp;
    public TextMeshProUGUI detail_description;

    public float temp;
    public float pres;

    public void ChangeTempAndPres() {
        new SetTempAndPresCommand(temp, pres).AddToQueue();
    }

    public void LoadInfo(CardItem item) {
        temp = item.temperature;
        pres = item.pressure;
        detail_name.SetText(item.name);
        detail_press.SetText(item.pressure.ToString());
        detail_temp.SetText(item.temperature.ToString());
        detail_description.SetText(item.description);
    }
}
