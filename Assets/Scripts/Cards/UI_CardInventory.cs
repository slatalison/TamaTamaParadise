using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using CodeMonkey.Utils;
using TMPro;

public class UI_CardInventory : MonoBehaviour {
    private CardInventory cardInventory;
    [SerializeField] private Transform cardContainer;
    [SerializeField] private Transform cardTemplate;
    public CardDetail card_detail;
    [SerializeField] float itemSlotCellSize = 400f;
    public FundManager fundManager;
    private AudioSource _audio;
    public AudioClip applyConfigSound;
    int y = 0;

    private void Start() {
        //cardContainer = transform.Find("CardContainer");
        //cardTemplate = cardContainer.Find("CardPrefab");
        fundManager = FindObjectOfType<FundManager>();
        _audio = GetComponent<AudioSource>();
    }

    public void SetCardInventory(CardInventory cardInventory) {
        this.cardInventory = cardInventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems() {
        foreach (CardItem cardItem in cardInventory.GetItemList()) {
            RectTransform itemSlotRectTransform = Instantiate(cardTemplate, cardContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            

            itemSlotRectTransform.anchoredPosition = new Vector2(127f, y * itemSlotCellSize);

            TextMeshProUGUI cardNameText = itemSlotRectTransform.Find("CardName").GetComponent<TextMeshProUGUI>();
            cardNameText.SetText(cardItem.name);

            TextMeshProUGUI cardPresText = itemSlotRectTransform.Find("Press").GetComponent<TextMeshProUGUI>();
            cardPresText.SetText(cardItem.pressure.ToString());

            TextMeshProUGUI cardTempText = itemSlotRectTransform.Find("Temp").GetComponent<TextMeshProUGUI>();
            cardTempText.SetText(cardItem.temperature.ToString());

            TextMeshProUGUI cardCostText = itemSlotRectTransform.Find("Cost").GetComponent<TextMeshProUGUI>();
            cardCostText.SetText(cardItem.cost.ToString());

            TextMeshProUGUI cardDesText = itemSlotRectTransform.Find("CardDescription").GetComponent<TextMeshProUGUI>();
            cardDesText.SetText(cardItem.description.ToString());

            TextMeshProUGUI cardlvText = itemSlotRectTransform.Find("CardLv").GetComponent<TextMeshProUGUI>();
            cardlvText.SetText(cardItem.CardLevel.ToString());

            //Button cardButton = itemSlotRectTransform.GetComponent<Button>();
            

            Button applyButton = itemSlotRectTransform.Find("ApplyButton").GetComponent<Button>();
            applyButton.onClick.AddListener(() => { card_detail.LoadInfo(cardItem); });
            applyButton.onClick.AddListener(() => { FindObjectOfType<CardDetail>().ChangeTempAndPres(cardItem); });
            applyButton.onClick.AddListener(() => { myAction(); });
            applyButton.onClick.AddListener(() => { _audio.PlayOneShot(applyConfigSound); });


            void myAction()
            {
                if(fundManager.foodCount >= cardItem.cost)
                {
                    applyButton.gameObject.SetActive(false);
                    
                }
                
            }

            

            //itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
            //card_detail.LoadInfo(cardItem);
            //};


            y--;

            //if (x > 4) {
            //    x = 0;
            //    y++;
            //}
        }
    }

}
