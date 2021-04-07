using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_TamaPanel : MonoBehaviour
{
    private UI_TamaPanel tamaPanel;
    [SerializeField] private Transform cellContainer;
    [SerializeField] private Transform cellTemplate;
    [SerializeField] float itemSlotCellSize = 400f;
    int x = 0;
    int y = 0;

    public List<TamaCollectionCell> tabButtons;
    public Sprite tabIdle;
    public Sprite tabActive;
    private AudioSource _audio;
    public AudioClip openTabSound;
    public void Subscribe(TamaCollectionCell button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<TamaCollectionCell>();
        }

        tabButtons.Add(button);
    }

    public void OnTabSelected(TamaCollectionCell button)
    {
        ResetTabs();
        button.background.sprite = tabActive;
        _audio.PlayOneShot(openTabSound);
    }

    public void ResetTabs()
    {
        foreach (TamaCollectionCell button in tabButtons)
        {
            button.background.sprite = tabIdle;
        }
    }

    private void Start()
    {
        SetTamaCollection(tamaPanel);
        _audio = GetComponent<AudioSource>();

    }

    public void SetTamaCollection(UI_TamaPanel tamaPanel)
    {
        this.tamaPanel = tamaPanel;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        for (int i = 0; i < 24; i ++)
        {
            RectTransform tamaCellItem = Instantiate(cellTemplate, cellContainer).GetComponent<RectTransform>();
            tamaCellItem.gameObject.SetActive(true);

            tamaCellItem.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
        }
    }


}
