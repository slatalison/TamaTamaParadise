using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelInteraction : MonoBehaviour
{

    public GameObject CardPanel;

    public void SwitchPanelStatus()
    {
        if (CardPanel != null)
        {
            CardPanel.SetActive(!CardPanel.activeInHierarchy);
        } else {
            Debug.LogError("[ERROR] CardPanel is set to null");
        }
    }
}
