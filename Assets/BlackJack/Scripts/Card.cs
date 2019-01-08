using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour {
    GameController gc;

    public int shape;
    public int number;

    public int cardLeft;
    private void Awake()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        cardLeft = gc.deckStatus.cardLeft;
        this.shape = Random.Range(1, 5);
        this.number = Random.Range(1, 11);
        this.gameObject.GetComponent<TextMeshProUGUI>().text = this.number.ToString();
    }
}
