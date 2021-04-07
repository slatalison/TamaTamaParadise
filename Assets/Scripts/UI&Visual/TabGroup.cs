using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<TabItem> tabItems;
    public Color colorIdle;
    public Color colorActive;
    public TabItem selectedTab;
    public float posYIdle = 260f;
    public float posYActive = 44f;
    public List<GameObject> panelsToSwap;
    [SerializeField] GameObject _EnvConfigPanel;
    private AudioSource _audio;
    public AudioClip openTabSound;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void Subscribe(TabItem tab)
    {
        if(tabItems == null)
        {
            tabItems = new List<TabItem>();
        }

        tabItems.Add(tab);
    }


    public void OnTabSelected(TabItem tab)
    {
        selectedTab = tab;

        ResetTabs();
        tab.background.color = colorActive;
        _audio.PlayOneShot(openTabSound);
        TabMoveDown();       
        
        int index = tab.transform.GetSiblingIndex();
        for(int i=0; i < panelsToSwap.Count; i++)
        {
            if (i == index)
            {
               panelsToSwap[i].SetActive(true);
            }
            else
            {
                panelsToSwap[i].SetActive(false);
            }
        }
    }

    public void unselectTab(TabItem tab)
    {
        selectedTab = tab;
        TabMoveUp();
        ResetTabs();
        int index = tab.transform.GetSiblingIndex();
        for (int i = 0; i < panelsToSwap.Count; i++)
        {
            if (i == index)
            {
                panelsToSwap[i].SetActive(false);
            }
        }
    }


    public void ResetTabs()
    {
        
        _audio.PlayOneShot(openTabSound);
        foreach (TabItem tab in tabItems)
        {
           
            if(selectedTab != null && tab == selectedTab)
            {
                continue;
            }
            tab.background.color = colorIdle;
        }
    }

    public void TabMoveDown()
    {
        _EnvConfigPanel.transform.position = new Vector2 (_EnvConfigPanel.transform.position.x, -220f);
        //Debug.Log(_EnvConfigPanel.transform.position);
        foreach (TabItem tabItem in tabItems)
        {
            tabItem.transform.position = new Vector2(tabItem.transform.position.x, posYActive);

        }
    }

    public void TabMoveUp()
    {
        _EnvConfigPanel.transform.position = new Vector2(_EnvConfigPanel.transform.position.x, 0);
        foreach (TabItem tabItem in tabItems)
        {
            tabItem.transform.position = new Vector2(tabItem.transform.position.x, posYIdle);
        }
    }


}
