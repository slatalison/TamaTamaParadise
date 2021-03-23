using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using TMPro;

public class UI_CardInventory : MonoBehaviour {
    private CardInventory cardInventory;
    [SerializeField] private Transform cardContainer;
    [SerializeField] private Transform cardTemplate;
    public CardDetail card_detail;

    private void Start() {
        //cardContainer = transform.Find("CardContainer");
        //cardTemplate = cardContainer.Find("CardPrefab");
    }

    public void SetCardInventory(CardInventory cardInventory) {
        this.cardInventory = cardInventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems() {
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 400f;
        foreach (CardItem cardItem in cardInventory.GetItemList()) {
            RectTransform itemSlotRectTransform = Instantiate(cardTemplate, cardContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

            TextMeshProUGUI cardNameText = itemSlotRectTransform.Find("CardName").GetComponent<TextMeshProUGUI>();
            cardNameText.SetText(cardItem.name);

            TextMeshProUGUI cardPresText = itemSlotRectTransform.Find("Press").GetComponent<TextMeshProUGUI>();
            cardPresText.SetText(cardItem.pressure.ToString());

            TextMeshProUGUI cardTempText = itemSlotRectTransform.Find("Temp").GetComponent<TextMeshProUGUI>();
            cardTempText.SetText(cardItem.temperature.ToString());

            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
                card_detail.LoadInfo(cardItem);
            };


            y--;

            //if (x > 4) {
            //    x = 0;
            //    y++;
            //}
        }
    }

}
