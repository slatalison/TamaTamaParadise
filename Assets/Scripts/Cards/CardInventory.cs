using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInventory {
    private List<CardItem> cardItemList;
    public CardInventory() {
        cardItemList = new List<CardItem>();

        AddCardItem(new CardItem { cardItemType = CardItemType.Card1, amount = 1, name = "Peace", pressure = 31f, temperature = 56f, description = "Warm and free. Enjoy the boring peacefulness." });
        AddCardItem(new CardItem { cardItemType = CardItemType.Card2, amount = 1, name = "War", pressure = 89f, temperature = 77f, description = "Hot and stressful. Be aggressive." });
        AddCardItem(new CardItem { cardItemType = CardItemType.Card4, amount = 1, name = "Madness", pressure = 88f, temperature = 3f, description = "What the hell is going on there? You're being a mad scientist?" });
    }

    public void AddCardItem(CardItem cardItem) {
        cardItemList.Add(cardItem);
    }

    public List<CardItem> GetItemList() {
        return cardItemList;
    }

}
