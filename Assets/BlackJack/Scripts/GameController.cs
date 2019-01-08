using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameController : MonoBehaviour {

    public Deck deckStatus;
    public int money;
    public bool gameStatus;

    public GameObject cardPrefab;
    public GameObject playerField, dealerField;

    private int gap = 80;

    UiContoller uc;

    public void Start()
    {
        deckStatus = new Deck();
        gameStatus = false;
        money = 10000;

        uc = this.gameObject.GetComponent<UiContoller>();

        
    }

    public void initDeckStatus(int deckCount, int cardsLeft, int shufflePoint)
    {
        deckStatus = new Deck();
        deckStatus.deckCount = deckCount;
        deckStatus.cardLeft = cardsLeft;
        deckStatus.shufflePoint = shufflePoint;

        Debug.Log("init decks: " + deckStatus.deckCount + " cardLeft: " + deckStatus.cardLeft + " shufflePoint: " + deckStatus.shufflePoint);
    }

 
    public void updateDeckStatus(int cardsLeft)
    {
        deckStatus.cardLeft = cardsLeft;
        uc.updateCardCountUI(deckStatus.cardLeft);
    }

    //this function is called from wallet.cs (betPrompt screen button)
    public void startBlackJack()
    {
            StartCoroutine(dealCardForAll(2));           
        
    }

    IEnumerator dealCardForAll(int repeat = 1)
    {
        for (int i = 0; i<repeat; i++)
        {
            yield return new WaitForSeconds(1);
            deckStatus.cardLeft -= 1;
            updateDeckStatus(deckStatus.cardLeft);
            Vector3 playerHandPos = playerField.transform.position;
            Instantiate(cardPrefab, playerHandPos + new Vector3(gap, 0, 0), playerField.transform.rotation, playerField.transform);
            yield return new WaitForSeconds(1);
            deckStatus.cardLeft -= 1;
            updateDeckStatus(deckStatus.cardLeft);
            Vector3 dealerHandPos = dealerField.transform.position;
            Instantiate(cardPrefab, dealerHandPos + new Vector3(gap, 0, 0), dealerField.transform.rotation, dealerField.transform);
            yield return new WaitForSeconds(1);
            gap += 80;
        }
        
    }

    IEnumerator dealCard(Transform player)
    {
        yield return new WaitForSeconds(1);
        deckStatus.cardLeft -= 1;
        updateDeckStatus(deckStatus.cardLeft);
        Vector3 handPos = player.position;
        Instantiate(cardPrefab, handPos + new Vector3(gap, 0, 0), player.rotation,player);
        gap += 80;
        yield return new WaitForSeconds(1);
    }



}
