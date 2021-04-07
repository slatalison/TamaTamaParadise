using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigCardGroup : MonoBehaviour
{
    public List<ConfigItem> configItems;
    public float xIdle;
    public float xActive;
    public Color colorIdle;
    public Color colorActive;
    public ConfigItem selectedTab;


    public void Subscribe(ConfigItem tab)
    {
        if (configItems == null)
        {
            configItems = new List<ConfigItem>();
        }

        configItems.Add(tab);
    }


    public void OnTabSelected(ConfigItem tab)
    {
        selectedTab = tab;
        ResetTabs();
        tab.gameObject.transform.position = new Vector2(xActive, tab.background.transform.position.y);
        tab.background.color = colorActive;
        tab.transform.Find("ApplyButton").gameObject.SetActive(true);

    }

    public void unselectTab(ConfigItem tab)
    {
        selectedTab = tab;
        ResetTabs();
    }


    public void ResetTabs()
    {
        foreach (ConfigItem tab in configItems)
        {

            if (selectedTab != null && tab == selectedTab)
            {
                continue;
            }
            tab.gameObject.transform.position = new Vector2(xIdle, tab.background.transform.position.y);
            tab.background.color = colorIdle;
            tab.transform.Find("ApplyButton").gameObject.SetActive(false);
        }
    }


}
