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
    public GameObject levelUpPanel;
    private AudioSource _audio;
    [SerializeField] AudioClip levelUpSound;

    void Start()
    {
        playerLevelText = gameObject.GetComponent<TextMeshProUGUI>();
        expBarImage = GameObject.Find("_GameCanvas/_TopBar/_LevelBackdrop/_expBar").GetComponent<Image>();
        playerLevelText.SetText("1");
        expBarImage.fillAmount = 0;
        _audio = gameObject.GetComponent<AudioSource>();
    }

    public void PlayerLevelUp()
    {
        if (playerLevelNumber < levelUpThreshold.Length) {
            playerLevelNumber++;
            _audio.PlayOneShot(levelUpSound);
            levelUpPanel.SetActive(true);
            playerLevelText.SetText((playerLevelNumber + 1).ToString());
        }
    }

    public void PlayerExpGrow(int amount)
    {
        playerExp += amount;
        expBarImage.fillAmount += (float)GetExpDelta(amount) / (float)GetLevelUpDelta(playerLevelNumber);
        //Debug.Log(amount + " " + playerExp);
    }


    public int GetLevelUpDelta(int playerLevelNumber)
    {
        if (playerLevelNumber > 0)
        {
            return (levelUpThreshold[playerLevelNumber] - levelUpThreshold[playerLevelNumber - 1]);
        }else
        {
            return levelUpThreshold[playerLevelNumber];
        }

    }

    public int GetExpDelta(int amount)
    {
       if (playerExp >= levelUpThreshold[levelUpThreshold.Length - 1])
        {
            return 0;
        } else
        {
            return amount;
        }

    }

    public void DisablePanel()
    {
        levelUpPanel.SetActive(false);
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
