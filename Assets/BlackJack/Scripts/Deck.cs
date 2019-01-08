using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck {

    public int deckCount,cardLeft, shufflePoint;
   


    public Deck (int deckCount = 1, int cardLeft = 52, int shufflePoint =42)
    {
        this.deckCount = deckCount;
        this.cardLeft = cardLeft;
        this.shufflePoint = shufflePoint;
    }

    
	
}
