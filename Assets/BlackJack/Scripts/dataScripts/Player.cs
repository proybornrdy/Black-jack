using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player{

    public Wallet playerWallet;
    public int playerID;
    public List<List<Card>> playerHand;
    public int[] playerPoint;

    public Player(int playerID = 0)
    {
        this.playerID = playerID;
        this.playerHand = new List<List<Card>>();
        this.playerWallet = new Wallet();
        playerPoint = new int[4] { 0, 0, 0, 0 };
         
    }

    //performed when player gets dealed with a new card
    public int getPlayerPoint(int handIndex)
    {
        List<Card> currHand = playerHand[handIndex];
        int sum = 0;
        foreach (Card card in currHand)
        {
            int cardPoint = card.cardValue;
           
            
            if (cardPoint > 10) cardPoint = 10;
            sum += cardPoint;
        }
        playerPoint[handIndex] = sum;
        return playerPoint[handIndex];
    }

    
    public bool checkBust(int handIndex)
    {
        Debug.Log("potin "+ playerPoint[handIndex]);
        if (playerPoint[handIndex] > 21)
        {
            //busted clear hand 
            List<Card> currHand = new List<Card>();
            playerHand[handIndex] = currHand;
            playerPoint[handIndex] = 0;

            return true;
        }
        else return false;
    }
	
}
