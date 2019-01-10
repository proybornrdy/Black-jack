using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card {

    public int cardValue;
    public string cardShape;    


    public void makeCard(int cardValue, string cardShape)
    {
        this.cardValue = cardValue;
        this.cardShape = cardShape;
    }
    public void updateCard(Card card)
    {
        this.cardValue = card.cardValue;
        this.cardShape = card.cardShape;
    }

}
