using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour {
    //this class controlls general gameplay flow

    public Deck deck;
    public Player player, dealer;

    public GameObject moneyField, betField, cardCountField,
        cardPrefab, playerPos, dealerPos,
        valueP, valueD;

    public bool gameStatus;

    private int betAmount;

    private int gap;
    
    public void Start()
    {
        //pre-stage setup
        deck = new Deck();
        player = new Player();
        dealer = new Player();
        moneyField.GetComponent<TextMeshProUGUI>().text = player.playerWallet.money.ToString() ;
        betAmount = 0;
        gameStatus = false;

        gap = 0;

    }

    //betting stage
    public void changeBetAmount(int i)
    {
        int playerBet = player.playerWallet.betAmount;
        this.betAmount += playerBet * i;
        if (betAmount <= player.playerWallet.money && betAmount >= 0)
        {
            betField.GetComponent<TextMeshProUGUI>().text = betAmount.ToString();
            moneyField.GetComponent<TextMeshProUGUI>().text = (player.playerWallet.money-betAmount).ToString();
        }       
    }
    public void startBlackJack()
    {
        //update player's Wallet
        player.playerWallet.money -= betAmount;
        player.playerWallet.totalMoneySpent += betAmount;

        //start dealing card
        StartCoroutine(dealCardsForAll(2));

    }

    public void hitCard()
    {
        StartCoroutine(dealSingleCard(player, playerPos));
        
        
    }

    IEnumerator dealSingleCard(Player player , GameObject playerPos)
    {
        yield return new WaitForSeconds(1);
        Card newCard = deck.dealCard();
        player.playerHand[0].Add(newCard);
        
        cardCountField.GetComponent<TextMeshProUGUI>().text = deck.cardLeft.ToString();
        cardPrefab.GetComponent<cardPrefab>().updateCard(newCard);
        Instantiate(cardPrefab, playerPos.transform.position + new Vector3(gap, 0, 0), playerPos.transform.rotation, playerPos.transform);
        cardPrefab.GetComponent<cardPrefab>().updateCard(newCard);
        valueP.GetComponent<TextMeshProUGUI>().text = player.getPlayerPoint(0).ToString();
        gap += 30;

        yield return new WaitForSeconds(1);
        bool checkBust = player.checkBust(0);
        Debug.Log(checkBust);

        if (checkBust)
        {
            //player is busted
            //  1. clear playerField and dealerField
            //  2. re -call bet prompt (unity side: can be ignored)
            foreach (Transform child in playerPos.transform)
            {
                Destroy(child.gameObject);
            }
            foreach (Transform child in dealerPos.transform)
            {
                Destroy(child.gameObject);
            }
        }

    }

    IEnumerator dealCardsForAll(int repeat = 1)
    {
        List<Card> startingPlayerHand = new List<Card>();
        List<Card> startingDealerHand = new List<Card>();
        for (int i = 0; i < repeat; i++)
        {
            yield return new WaitForSeconds(1);
            Card newCard = deck.dealCard();

            
            startingPlayerHand.Add(newCard);
            cardCountField.GetComponent<TextMeshProUGUI>().text = deck.cardLeft.ToString();
            cardPrefab = cardPrefab.GetComponent<cardPrefab>().updateCard(newCard);
            Instantiate(cardPrefab, playerPos.transform.position + new Vector3(gap, 0, 0), playerPos.transform.rotation, playerPos.transform);
            

            yield return new WaitForSeconds(1);
            newCard = deck.dealCard();
            startingDealerHand.Add(newCard);
            cardCountField.GetComponent<TextMeshProUGUI>().text = deck.cardLeft.ToString();
            cardPrefab = cardPrefab.GetComponent<cardPrefab>().updateCard(newCard);
            Instantiate(cardPrefab, dealerPos.transform.position + new Vector3(gap, 0, 0), dealerPos.transform.rotation, dealerPos.transform);
            cardPrefab.GetComponent<cardPrefab>().updateCard(newCard);

            gap += 30;
        }
        player.playerHand.Add(startingPlayerHand);
        valueP.GetComponent<TextMeshProUGUI>().text = player.getPlayerPoint(0).ToString();
        dealer.playerHand.Add(startingDealerHand);
        valueD.GetComponent<TextMeshProUGUI>().text = dealer.getPlayerPoint(0).ToString();

    }

    ////this function is called from wallet.cs (betPrompt screen button)
    //public void startBlackJack()
    //{
    //        StartCoroutine(dealCardForAll(2));           
        
    //}

    //IEnumerator dealCardForAll(int repeat = 1)
    //{
    //    for (int i = 0; i<repeat; i++)
    //    {
    //        yield return new WaitForSeconds(1);
    //        deckStatus.cardLeft -= 1;
    //        updateDeckStatus(deckStatus.cardLeft);
    //        Vector3 playerHandPos = playerField.transform.position;
    //        Instantiate(cardPrefab, playerHandPos + new Vector3(gap, 0, 0), playerField.transform.rotation, playerField.transform);
    //        yield return new WaitForSeconds(1);
    //        deckStatus.cardLeft -= 1;
    //        updateDeckStatus(deckStatus.cardLeft);
    //        Vector3 dealerHandPos = dealerField.transform.position;
    //        Instantiate(cardPrefab, dealerHandPos + new Vector3(gap, 0, 0), dealerField.transform.rotation, dealerField.transform);
    //        yield return new WaitForSeconds(1);
    //        gap += 80;
    //    }
        
    //}

    //IEnumerator dealCard(Transform player)
    //{
    //    yield return new WaitForSeconds(1);
    //    deckStatus.cardLeft -= 1;
    //    updateDeckStatus(deckStatus.cardLeft);
    //    Vector3 handPos = player.position;
    //    Instantiate(cardPrefab, handPos + new Vector3(gap, 0, 0), player.rotation,player);
    //    gap += 80;
    //    yield return new WaitForSeconds(1);
    //}



}
