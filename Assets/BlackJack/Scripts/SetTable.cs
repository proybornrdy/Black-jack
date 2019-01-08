using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetTable : MonoBehaviour {

    

    Deck deckStatus;
    GameController gc;
    UiContoller uc;
    public Button startBtn;
 

    public void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        uc = GameObject.Find("GameController").GetComponent<UiContoller>();
        
        deckStatus = new Deck();
    }
    // can play with 1 to 8 decks---------------
    public void increaseDeck()
    {   
        
        if (deckStatus.deckCount.Equals(8) || gc.gameStatus)
        {
            Debug.Log("cannot perform action");
        }
        else
        {
            deckStatus.deckCount += 1;
        }
        uc.updateDeckCountUI(deckStatus.deckCount);
    }

    public void decreaseDeck()
    {        
        if (deckStatus.deckCount <= 1 || gc.gameStatus)
        {
            Debug.Log("cannot perform action");
        }
        else
        {
            deckStatus.deckCount -= 1;
        }
        uc.updateDeckCountUI(deckStatus.deckCount);
    }

    public void setUpComplete()
    {
        if (!gc.gameStatus)
        {
            startBtn.interactable = false;
            int deckCount = deckStatus.deckCount;
            int cardsLeft = deckCount * 52;
            int shufflePoint = cardsLeft - (int)Random.Range(cardsLeft / 8f, cardsLeft / 4f);
            gc.initDeckStatus(deckCount, cardsLeft, shufflePoint);
            uc.updateCardCountUI(cardsLeft);
            gc.gameStatus = true;
        }
            
    }

    

    public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
