using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ConfigApplyButton : MonoBehaviour, IPointerClickHandler
{
    public CardDetail card_detail;

    public void OnPointerClick(PointerEventData eventData)
    {


    }

    // Start is called before the first frame update
    void Start()
    {
        card_detail = transform.parent.GetComponent<CardDetail>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
