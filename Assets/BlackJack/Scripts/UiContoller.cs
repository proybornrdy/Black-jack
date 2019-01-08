using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiContoller : MonoBehaviour {

    //game setting variables:
    public GameObject deckCountObj;
    public GameObject cardCountObj;

    //wallet variables:
    public GameObject moneyObj;
    public GameObject betObj;

    public void updateDeckCountUI(int deckCount)
    {
        deckCountObj.GetComponent<TextMeshProUGUI>().text = deckCount.ToString();
    }
    public void updateCardCountUI(int cardCount)
    {
        cardCountObj.GetComponent<TextMeshProUGUI>().text = cardCount.ToString();
    }
    public void updateMoneyUI(int money)
    {
        moneyObj.GetComponent<TextMeshProUGUI>().text = money.ToString();
    }
    public void updateBetAmountUI(int bet)
    {
        betObj.GetComponent<TextMeshProUGUI>().text = bet.ToString();
    }
}
