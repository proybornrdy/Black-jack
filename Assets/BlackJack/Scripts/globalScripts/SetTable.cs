using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SetTable : MonoBehaviour {

    public Deck deckStat;

    public GameObject deckCountObj;
    public GameObject totalCardsObj;
    private string deckCount;


    // contains UI that needs to be displayed on screen
    // dataUIs[0] = total cards left in deck 
    // dataUIs[1] = player's money left in wallet    
    public GameObject[] dataUIs;

    public void Start()
    {
       
    }

    public void tableSetup( Deck deck, List<Player> players)
    {        
        int numOfDeck = deck.deckCount;
        int cardsLeft = deck.cardLeft;

        Player player = players[0]; //TODO: figure out how to set up multiplayer environment
        int playerMoney = player.playerWallet.money;

        dataUIs[0].GetComponent<TextMeshProUGUI>().text = cardsLeft.ToString();
        dataUIs[1].GetComponent<TextMeshProUGUI>().text = playerMoney.ToString();
        
    }

    public void finishSetUp (Button startBtn)
    {
        //setup new deck according to the setting
        deckStat = new Deck(int.Parse(deckCount));
        //update new deck to main controlling system -- GameController.cs
        //gc.deck = deckStat;
        //gc.gameStatus = true;
        
        //update ui
        totalCardsObj.GetComponent<TextMeshProUGUI>().text = deckStat.cardLeft.ToString() ;
        startBtn.interactable = false;
    }

    public void changeDeckCount(int i)
    {
        int tempCount = int.Parse(deckCount) + i;
        if (tempCount > 0 && tempCount <= 8)
        {
            deckCount = (int.Parse(deckCount) + i).ToString();

            //update changed value to canvas --visualize
            deckCountObj.GetComponent<TextMeshProUGUI>().text = deckCount;
        }        
    }

    public void resetTable()
    {

    }



    public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }    

}
