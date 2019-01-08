using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setup : MonoBehaviour {

    public GameObject currDeckCountGameObj;
    public GameObject cardsInDeckGameObj;

    public GameObject cardPrefab;
    public GameObject playerCardArea;
    public GameObject dealerCardArea;

    private Transform dealerCardsPos;
    private Transform playerCardPos;
    private Vector3 tempPlayerPos;

    private TextMeshProUGUI currDeckCount;
    private TextMeshProUGUI cardsInDeck;
    private int deckCount;
    private int totalCardsInDeck;

    private int[] playerHand;
    private int[] dealerHand;

    public void Start()
    {
        currDeckCount = currDeckCountGameObj.GetComponent<TextMeshProUGUI>();
        deckCount = int.Parse(currDeckCount.text);
        cardsInDeck = cardsInDeckGameObj.GetComponent<TextMeshProUGUI>();
        totalCardsInDeck = int.Parse(cardsInDeck.text);
        dealerCardsPos = dealerCardArea.transform;
        playerCardPos = playerCardArea.transform;
        tempPlayerPos = playerCardPos.transform.position;
    }   

    public void increaseDeck()
    {   
        if (deckCount.Equals(8))
        {
            Debug.Log("cannot perform action");
        }
        else
        {
            deckCount += 1;
        }
        currDeckCount.text = deckCount.ToString();
    }

    public void decreaseDeck()
    {        
        if (deckCount<=1)
        {
            Debug.Log("cannot perform action");
        }
        else
        {
            deckCount -= 1;
        }
        currDeckCount.text = deckCount.ToString();
    }

    public void startGame()
    {

        if (deckCount >= 1 && deckCount <= 8)
        {
            Debug.Log("game start with " + deckCount + " decks");
            totalCardsInDeck = 52*deckCount;
            cardsInDeck.text = totalCardsInDeck.ToString();

            //start blackjack game - currently ignored first bets.
            StartCoroutine(dealCardForAll());
        }
        else
        {
            Debug.Log("Cannot start game: deck index out of range");
        }
    }

    public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator dealCardForAll()
    {
        yield return new WaitForSeconds(1);
        totalCardsInDeck -= 1;
        cardsInDeck.text = totalCardsInDeck.ToString();
        Instantiate(cardPrefab, playerCardPos);
        yield return new WaitForSeconds(1);
        totalCardsInDeck -= 1;
        cardsInDeck.text = totalCardsInDeck.ToString();
        Instantiate(cardPrefab, dealerCardsPos);
        yield return new WaitForSeconds(1);
    }

    IEnumerator dealCard(Transform player)
    {
        yield return new WaitForSeconds(1);        
        totalCardsInDeck -= 1;
        cardsInDeck.text = totalCardsInDeck.ToString();
        tempPlayerPos = tempPlayerPos + new Vector3(80, 0, 0);
        Instantiate(cardPrefab, tempPlayerPos, player.rotation, playerCardPos);
        yield return new WaitForSeconds(1);
        
        
        Debug.Log("complete coroutine");
    }

    public void hitCard()
    {
        StartCoroutine(dealCard(playerCardPos));
    }
}
