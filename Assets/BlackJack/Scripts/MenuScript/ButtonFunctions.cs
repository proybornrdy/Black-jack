using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonFunctions : MonoBehaviour {

    //most of start menu button functionalities are done on unity itself
    //but for special cases, uses this script for complex button functions

    //buttons that require seperate functions
    public GameObject backBtn, startBtn;

    // group of gameobjs for different scene of the game
    // gameScenes[0] = game startMenu
    // gameScenes[1] = main game Scene
    public GameObject[] gameScenes;

    //contains popup menus
    //menuPopups[0] = tableSetup menu
    //menuPopups[1] = option menu
    public GameObject[] menuPopups;

    //contains table set up constructor
    //tableSetUp[0] = number of decks 
    //tableSetUp[1:n] = all toggle gameobjs -initialized in unity engine
    public GameObject[] tableSetUp;

    //buttons for optional gameplay such as: surrender, evenMoney, insurace, push 
    //(for now there is only surrender)
    public GameObject[] gameOptions;

    GameController gc;

    private bool setUp;
    private int openedPopupIndex;

    //contains data 
    //options[0] = number of decks
    //options[1] = number of players
    //options[2:n] = blackjack options
    private List<string> options;

    


    public void Start()
    {
        setUp = false;
        openedPopupIndex = -1;
        options = new List<string>();
        
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    /**_______________________ GLOBAL BTN FUNCTION_______________________________________ **/
    public void btnChangeNumber(int i = 1)
    {
        if (openedPopupIndex == 0) //case for table Setup
        {
            
            int numDeck = int.Parse(tableSetUp[0].GetComponent<TextMeshProUGUI>().text);
            if (i > 0)
            {
                if (numDeck > 0 && numDeck < 8) numDeck = numDeck + 1 * i;
            }
            else
            {
                if (numDeck > 1 && numDeck < 9) numDeck = numDeck + 1 * i;
            }
            
            tableSetUp[0].GetComponent<TextMeshProUGUI>().text = numDeck.ToString();
        }
    }

    /**_________________________________________________________________________________ **/

    /**_______________________ start Menu BTN FUNCTION_______________________________________**/

    public void btnStart() 
    {
        if (setUp)
        {
            //game is ready for launch 
            //deactivate current scene and open game 
            gameScenes[0].SetActive(false);
            gameScenes[1].SetActive(true);

            //get player set settings
            options.Add(tableSetUp[0].GetComponent<TextMeshProUGUI>().text);
            options.Add("1");//temporaliy set game to single player game ---------need to be changed later for multiplayer
            for (int i = 1; i < tableSetUp.Length; i++)
            {
                //adds options that are checked by users
                if (tableSetUp[i].GetComponent<Toggle>().isOn) options.Add(tableSetUp[i].name);  
            }
            gc.initTableSetup(options);
        }
        else 
        {
            //game is not yet ready to begin
            //open setup and mark setup is ready
            menuPopups[0].SetActive(true) ;
            openedPopupIndex = 0;
            setUp = true;
        }
    } 
    
    public void btnOption()
    {
        //todo: option
    }

    public void btnBack()
    {
        if (setUp && openedPopupIndex > -1)
        {
            //setup page is open so when pressed need to go back to mainmenu
            setUp = false;
            menuPopups[openedPopupIndex].SetActive(false);

            //because for cetain unknown reason button stays highlighted
            //reenable button to remove highlight
            backBtn.GetComponent<Button>().enabled = false;
            backBtn.GetComponent<Button>().enabled = true;
        }
        else
        {
            //when pressed Back in main menu, go back to game select menu
            // (however, it is not yet implemented so replace it with quit game)
            Debug.Log("successfully quit game");
            Application.Quit();
        }
    }
    /**_________________________________________________________________________________ **/

    /**_______________________ in game BTN FUNCTION_______________________________________**/
    public void enableOptions()
    {
        string[] possibleOptions = { "surrender", "evenMoney", "insurance", "push" };
        int optionCount = options.Count - 2;
        List<string> optionCheck = options.GetRange(2,optionCount);
        int i = 0;
        foreach (string option in possibleOptions)
        {
            if (option == optionCheck[0])
            {
                gameOptions[i].GetComponent<Button>().interactable = true;
            }
            i++;
        }
    }

    public void btnHit()
    {

    }
    public void btnDouble()
    {

    }
    public void btnStand()
    {

    }
    public void btnSplit()
    {

    }


    /**_________________________________________________________________________________ **/
}
