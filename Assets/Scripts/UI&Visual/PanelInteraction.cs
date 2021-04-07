using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInteraction : MonoBehaviour
{

    [SerializeField] GameObject myPanel;
    [SerializeField] Sprite selectedSprite;
    [SerializeField] Sprite unselectedSprite;
    private float space;
    [SerializeField] GameObject configTab;
    [SerializeField] GameObject taskTab;
    [SerializeField] GameObject tamasTab;

    [SerializeField] GameObject configPanel;
    [SerializeField] GameObject taskPanel;
    [SerializeField] GameObject tamasPanel;


    void Start()
    {


    }


    public void SwitchPanelStatus()
    {
        if(gameObject == configTab)
        {
            myPanel = configPanel;
        } else if(gameObject == taskTab)
        {

        }


        if (myPanel != null)
        {
            myPanel.SetActive(!myPanel.activeInHierarchy);

        }
        else
        {
            Debug.LogError("[ERROR] CardPanel is set to null");
        }
    }

    public void ChangeTabSprite()
    {
        if (myPanel.activeSelf == true)
        {
            gameObject.GetComponent<Image>().sprite = selectedSprite;
            if (gameObject == taskTab)
            {
                tamasTab.GetComponent<RectTransform>().anchoredPosition += new Vector2 (space, 0);
            }

        }
        else if (myPanel.activeSelf == false)
        {
            gameObject.GetComponent<Image>().sprite = unselectedSprite;
            if (gameObject == taskTab)
            {
                tamasTab.GetComponent<RectTransform>().anchoredPosition -= new Vector2(space, 0);
            }
        }




    }


}
