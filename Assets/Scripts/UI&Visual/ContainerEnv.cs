using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContainerEnv : MonoBehaviour {
    [SerializeField] private Image PresBar;
    [SerializeField] private Image TempBar;
    [SerializeField] private TextMeshProUGUI presGauge;
    [SerializeField] private TextMeshProUGUI tempGauge;
    [SerializeField] public float CurrentTemp = 30f;
    [SerializeField] public float CurrentPres = 30f;
    [SerializeField] public TextMeshProUGUI currentConfigName;
    public float MaxPres = 100f;
    public float MaxTemp = 100f;
    private CardInventory cardInventory;
    [SerializeField] private UI_CardInventory ui_cardInventory;

    public delegate void EnvChange(float temp, float pres);
    public static EnvChange tempPresChange;
    
    private void Start() {



        //new inventory
        cardInventory = new CardInventory();
        ui_cardInventory.SetCardInventory(cardInventory);
    }

    private void Update() {
        //display press and temp bar
        TempBar.fillAmount = CurrentTemp / MaxTemp;
        PresBar.fillAmount = CurrentPres / MaxPres;
        if(CurrentTemp < 25f)
        {
            tempGauge.text = "Unconcerned";
        }else if(CurrentTemp >= 25f && CurrentTemp < 50f)
        {
            tempGauge.text = "Niche-picked";
        }else if(CurrentTemp >= 50f && CurrentTemp < 75f)
        {
            tempGauge.text = "Devoted";
        }else if (CurrentTemp <= 100f)
        {
            tempGauge.text = "Fanatical";
        }

        if (CurrentPres < 25f)
        {
            presGauge.text = "Orderless";
        }
        else if (CurrentPres >= 25f && CurrentPres < 50f)
        {
            presGauge.text = "Liberal";
        }
        else if (CurrentPres >= 50f && CurrentPres < 75f)
        {
            presGauge.text = "Restircted";
        }
        else if (CurrentPres <= 100f)
        {
            presGauge.text = "Silenced";
        }
    }

    public void SetTempAndPres(float temp, float pres, string name) {
        this.CurrentTemp = temp;
        this.CurrentPres = pres;
        currentConfigName.text = name;
        if (tempPresChange != null) {
            tempPresChange(temp, pres);
        }

        //Debug.Log(temp + "/" + pres);
    }
} 
