using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardDetail : MonoBehaviour
{

    public TextMeshProUGUI detail_name;
    public FundManager fundManager;
    public TextMeshProUGUI detail_press;
    public TextMeshProUGUI detail_temp;
    public TextMeshProUGUI detail_description;
    public TextMeshProUGUI detail_Lv;
    //public TextMeshProUGUI detail_cost;

    public float temp;
    public float pres;
    public int cost;


    public void ChangeTempAndPres(CardItem item) {

        if (fundManager.foodCount >= item.cost)
        {
            fundManager.Decrease(cost);
            new SetTempAndPresCommand(temp, pres, detail_name.text).AddToQueue();
        }

    }

    public void LoadInfo(CardItem item) {
        if (fundManager.foodCount >= item.cost)
        {
            temp = item.temperature;
            pres = item.pressure;
            cost = item.cost;
            detail_name.SetText(item.name);
            detail_press.SetText(item.pressure.ToString());
            detail_temp.SetText(item.temperature.ToString());
            detail_description.SetText(item.description);
            //detail_cost.SetText(item.cost.ToString());
            detail_Lv.SetText(item.CardLevel.ToString());
        }
    }

}
