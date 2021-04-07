using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class TabItem : MonoBehaviour, IPointerClickHandler
{
    public TabGroup tabGroup;
    public Image background;
    [SerializeField] GameObject myTab;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if(myTab.activeSelf == false)
        {
            tabGroup.OnTabSelected(this);
        }else if(myTab.activeSelf == true)
        {
            tabGroup.unselectTab(this);
        }
        
    }

    void Start()
    {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
