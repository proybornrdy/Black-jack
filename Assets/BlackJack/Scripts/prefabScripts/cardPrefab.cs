using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cardPrefab : MonoBehaviour {

    Card card;
    public string cardValue, cardShape;

    private void Awake()
    {                
        this.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = cardValue + "\r\n" + cardShape;
    }
    public GameObject updateCard(Card newCard)
    {
        cardValue = newCard.cardValue.ToString();
        cardShape = newCard.cardShape;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = cardValue + "\r\n" + cardShape;
        return this.gameObject;
    }
}
