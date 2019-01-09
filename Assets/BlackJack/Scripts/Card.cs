using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour {

    public int cardValue;
    public string cardShape;

    public Card(int cardValue, string cardShape)
    {
        this.cardValue = cardValue;
        this.cardShape = cardShape;
    }
    public void updateCard(Card card)
    {
        this.cardValue = card.cardValue;
        this.cardShape = card.cardShape;
    }

    public void Awake()
    {
        this.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = cardValue.ToString() + "\r\n" + cardShape;
    }


}
