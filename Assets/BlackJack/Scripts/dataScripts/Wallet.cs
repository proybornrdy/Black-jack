using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wallet{

    public int money, betAmount, totalMoneySpent, totalMoneyEarned;
    public int[] handBets;

    //player's wallet constructor
    public Wallet(int money = 10000, int betAmount = 100 , int[] handBets = null)
    {
        this.money = money;
        
        if (handBets == null)
        {
            int[] sampleHand = { betAmount };
            this.handBets = sampleHand;
        }
        else
        {
            this.handBets = handBets;
        }      
        
    }

    public void updateWallet(int money = 0, int betAmount = 0, int totalMoneySpent = 0, int totalMoneyEarned = 0)
    {
        this.money += money;
        this.betAmount += betAmount;
        this.totalMoneyEarned += totalMoneyEarned;
        this.totalMoneySpent += totalMoneySpent;
    }

    //GameController gc;
    //UiContoller uc;
    //Wallet wallet;
    //public int money, betAmount;


    //public void Start()
    //{
    //    gc = GameObject.Find("GameController").GetComponent<GameController>();
    //    uc = GameObject.Find("GameController").GetComponent<UiContoller>();
    //    betAmount = 100;
    //}

    //public void increaseBet()
    //{
    //    if (gc.money - (betAmount + 100) >= 0)
    //    {
    //        betAmount += 100;
    //        uc.updateBetAmountUI(betAmount);
    //    }        
    //}
    //public void decreaseBet()
    //{
    //    if (betAmount > 100)
    //    {
    //        betAmount -= 100;
    //        uc.updateBetAmountUI(betAmount);
    //    }
    //}
    //public void bet()
    //{
    //    gc.money = gc.money - betAmount;
    //    uc.updateMoneyUI(gc.money);
    //    gc.startBlackJack();
    //}
}
