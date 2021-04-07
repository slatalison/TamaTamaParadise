using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Image))]
public class TamaCollectionCell : MonoBehaviour, IPointerClickHandler
{

    public UI_TamaPanel tabGroup;
    public Image background;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }


    // Start is called before the first frame update
    void Start()
    {
        tabGroup = FindObjectOfType<UI_TamaPanel>();
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
