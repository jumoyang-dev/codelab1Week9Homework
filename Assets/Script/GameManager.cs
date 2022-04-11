using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //singleton
    private static GameManager instance;
    public static GameManager FindInstance()
    {
        return instance;
    }
    [Header("Slot")]
    public List<Slot> slot = new List<Slot>();
    [HideInInspector]
    public static bool allTaken;

    //cards spawned and display
    //deck: spawn list
    //display: spread out list 
    #region DeckObjectLists
    List<GameObject> deck = new List<GameObject>();
    List<GameObject> display = new List<GameObject>();
    #endregion


    #region CardData
    [HideInInspector]
    public GameObject selectedCard;
    [Header("Card Data")] //header in inspector 
    public GameObject cardObj;
    public int cardCount; //how many cards been spawned
    public int handCount;
    #endregion


    #region CardPositions
    [Header("Card Positions")]
    public GameObject displayPosSpot; //refer to the spot in the scene
    [HideInInspector]
    public Vector3 displayPos; //get the pos of display spot 
    public GameObject startPos; //refer to startpos spot in scene
    public float distancing; //distance between each cards
    
    #endregion
    [HideInInspector]
    public bool isDisplay;//check if already displayed

    //to spawn cards
    private void CreateCards()
    {
        for (int i = 0; i < cardCount; i++)
        {
            //spawn card with cardstate code
            //add card spawned to deck list 
            GameObject newCard = Instantiate(cardObj);
            CardState cS = newCard.GetComponent<CardState>();
            deck.Add(newCard);
            //move card to spawned position
            newCard.transform.position = startPos.transform.position;
        }
    }

    private void Start()
    {
        //spawn cards at the start 
        CreateCards();
    }

    private void Update()
    {
        //check if all 5 slots have cards displayed
        //then able to flip 
        if (slot[0].occupied && slot[1].occupied && slot[2].occupied && slot[3].occupied && slot[4].occupied)
        {
            allTaken = true;
            print(allTaken);
        }else
        {
            allTaken = false;
        }


        //avoid repeatly display
        if (!isDisplay)
        {
            displayCard();
        }

    }

    private void displayCard()
    {
        //starting from the last one in the list
        //and move the card to the displayposition and add distancing
        GameObject currentCard = deck[deck.Count - 1];
        currentCard.GetComponent<SpriteRenderer>().sortingOrder = handCount;
        //get the gamestate component
        CardState cS = currentCard.GetComponent<CardState>();
        //get the displayspot postion from the gameobject
        displayPos = displayPosSpot.transform.position;
        Vector3 newPos = new Vector3(displayPos.x + (display.Count * distancing), displayPos.y, 0);
        if (cS.MoveCard(newPos, 3f))
        {
            //move card from deck list to display list
            display.Add(currentCard);
            deck.RemoveAt(deck.Count - 1);

            //when deck count is 0, all cards been display
            if(deck.Count == 0)
            {
                isDisplay = true;
            }
        }
    }




}
