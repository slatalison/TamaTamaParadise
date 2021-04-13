﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInventory
{
    private List<CardItem> cardItemList;
    public CardInventory()
    {
        cardItemList = new List<CardItem>();

        AddCardItem(new CardItem { cardItemType = CardItemType.Card1, CardLevel = 1, name = "Defalut config", pressure = 90f, temperature = 10f, description = "Nothing happens. Tamas no longer produce Light Manna, nor dare they attack each other. What can be even worse than the dreadful boredness?", cost = 20 });
        AddCardItem(new CardItem { cardItemType = CardItemType.Card2, CardLevel = 1, name = "Calm", pressure = 70f, temperature = 25f, description = "Not too warm and not too free. Maybe a little bit boring too, but at least there is little violence.", cost = 10 });
        AddCardItem(new CardItem { cardItemType = CardItemType.Card3, CardLevel = 2, name = "Booming", pressure = 30f, temperature = 50f, description = "The community has not got the regulation and attention from the outside world, equals you. It grows at an incredible but also alarming speed.", cost = 30 });
        AddCardItem(new CardItem { cardItemType = CardItemType.Card4, CardLevel = 3, name = "Agenda driven", pressure = 85f, temperature = 85f, description = "Poor Tamas are now being used as laborers! They are pushed by the harsh config to make no trouble but produce Light Manna.", cost = 20 });
        AddCardItem(new CardItem { cardItemType = CardItemType.Card5, CardLevel = 3, name = "Political correctness", pressure = 75f, temperature = 65f, description = "Every Tama wants its voice to be heard. But if you listen, their voices are quite similar to each other. Perhaps, this is because there are too many You-Know-Whos in this petri dish.", cost = 20 });

    }

    public void AddCardItem(CardItem cardItem)
    {
        cardItemList.Add(cardItem);
    }

    public List<CardItem> GetItemList()
    {
        return cardItemList;
    }

}
