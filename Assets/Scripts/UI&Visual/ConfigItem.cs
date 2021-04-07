using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ConfigItem : MonoBehaviour, IPointerClickHandler
{
    public ConfigCardGroup ConfigCardGroup;
    public Image background;

    public void OnPointerClick(PointerEventData eventData)
    {

        ConfigCardGroup.OnTabSelected(this);
    }

    void Start()
    {
        background = GetComponent<Image>();
        ConfigCardGroup = FindObjectOfType<ConfigCardGroup>();
        ConfigCardGroup.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
