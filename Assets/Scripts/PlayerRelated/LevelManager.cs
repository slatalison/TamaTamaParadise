using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public TextMeshProUGUI playerLevelText;
    public int playerLevelNumber = 0;
    public int playerExp = 0;
    public Image expBarImage;
    public int[] levelUpThreshold = { 100, 200, 300, 400, 500 };
    //public int[] levelUpDelta = { 100, 100, 100, 100, 100 };

    void Start()
    {
        playerLevelText = gameObject.GetComponent<TextMeshProUGUI>();
        expBarImage = GameObject.Find("Canvas/TopBar/LevelBackdrop/expBar").GetComponent<Image>();
        playerLevelText.SetText("1");
        //expBarImage.fillAmount = 0;
    }

    public void PlayerLevelUp()
    {
        playerLevelNumber ++ ;
        playerLevelText.SetText((playerLevelNumber + 1).ToString());
    }

    public void PlayerExpGrow(int amount)
    {
        playerExp += amount;
        expBarImage.fillAmount = (float)GetExpDelta(playerExp) / (float)GetLevelUpDelta(playerLevelNumber);
    }

    public int GetLevelUpDelta(int playerLevelNumber)
    {
        if (playerLevelNumber > 0)
        {
            return (levelUpThreshold[playerLevelNumber] - levelUpThreshold[playerLevelNumber]);
        }else
        {
            return levelUpThreshold[playerLevelNumber];
        }

    }

    public int GetExpDelta(int playerExp)
    {
        if (playerExp > levelUpThreshold[0])
        {
            return (playerExp - levelUpThreshold[playerLevelNumber]);
        }
        else
        {
            return playerExp;
        }

    }

    void Update()
    {
        if(playerExp > levelUpThreshold[playerLevelNumber])
        {
            expBarImage.fillAmount = 0;
            PlayerLevelUp();
        }
    }

}
