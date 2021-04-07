using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContainerEnv : MonoBehaviour {
    [SerializeField] private Image PresBar;
    [SerializeField] private Image TempBar;
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
