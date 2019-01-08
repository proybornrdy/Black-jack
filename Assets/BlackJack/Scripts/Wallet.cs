using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour {


    GameController gc;
    UiContoller uc;
    Wallet wallet;
    public int money, betAmount;


    public void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        uc = GameObject.Find("GameController").GetComponent<UiContoller>();
        betAmount = 100;
    }

    public void increaseBet()
    {
        if (gc.money - (betAmount + 100) >= 0)
        {
            betAmount += 100;
            uc.updateBetAmountUI(betAmount);
        }        
    }
    public void decreaseBet()
    {
        if (betAmount > 100)
        {
            betAmount -= 100;
            uc.updateBetAmountUI(betAmount);
        }
    }
    public void bet()
    {
        gc.money = gc.money - betAmount;
        uc.updateMoneyUI(gc.money);
        gc.startBlackJack();
    }
}
