using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck {

    public int deckCount,cardLeft, shufflePoint;
    public Cards cardStat;
    public List<Cards> cardList;

    public Deck(int deckCount = 1)
    {
        
        this.deckCount = deckCount;
        cardLeft = deckCount * 52;
        shufflePoint = cardLeft - Random.Range(cardLeft / 8, cardLeft / 4);

        cardList = new List<Cards>();
        for (int i = 1; i<=13; i++)
        {
            cardStat = new Cards(i, deckCount);
            cardList.Add (cardStat);
        }
    }
     
    public Card dealCard()
    {
        int index = Random.Range(0, cardList.Count);
        Cards pickedCard = cardList[index];
        if (pickedCard.sameValueCount == 0) cardList.RemoveAt(index);
        Card card = pickedCard.removeCard();
        cardLeft -= 1;

        return card;
    }
}

public class Cards
{

    
    public int shapeCountH, shapeCountD, shapeCountC, shapeCountS;
    public int sameValueCount, cardValue;

    public Cards(int cardValue, int deckCount)
    {
        this.cardValue = cardValue;
        shapeCountC =shapeCountD = shapeCountH = shapeCountS = deckCount;
        sameValueCount = deckCount * 4;

    }

    //make sure to check if shapecount or valuecount is not below 0
    private void updateCards(string shape)
    {
        switch (shape)
        {
            case "Clover":              
                this.shapeCountC -= 1;
                break;
            case "Diamond":
                this.shapeCountD -= 1;
                break;
            case "Heart":
                this.shapeCountH -= 1;
                break;
            case "Spade":
                this.shapeCountS -= 1;
                break;            
        }
        this.sameValueCount -= 1;
    }

    public Card removeCard()
    {
        List<string> shape = new List<string>();
        if (shapeCountC > 0) shape.Add("Clover");
        if (shapeCountD > 0) shape.Add("Diamond");
        if (shapeCountH > 0) shape.Add("Heart");
        if (shapeCountS > 0) shape.Add("Spade");
        int shapeIndex = Random.Range(0, shape.Count);
        Card pickedCard = new Card(cardValue, shape[shapeIndex]);
        updateCards(shape[shapeIndex]);
        return pickedCard;
    }


}

