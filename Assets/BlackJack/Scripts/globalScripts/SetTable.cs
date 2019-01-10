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

    GameController gc;

    public void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        deckCount = deckCountObj.GetComponent<TextMeshProUGUI>().text;
        //placeholder for deckStat
        deckStat = new Deck(int.Parse(deckCount));
    }

    public void finishSetUp (Button startBtn)
    {
        //setup new deck according to the setting
        deckStat = new Deck(int.Parse(deckCount));
        //update new deck to main controlling system -- GameController.cs
        gc.deck = deckStat;
        gc.gameStatus = true;
        
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
