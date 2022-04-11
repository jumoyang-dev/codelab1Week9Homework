using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager FindInstance()
    {
        return instance;
    }

    #region DeckObjectLists
    List<GameObject> deck = new List<GameObject>();
    List<GameObject> display = new List<GameObject>();
    #endregion


    #region CardData
    [HideInInspector]
    public GameObject selectedCard;
    [Header("Card Data")] //header in inspector 
    public GameObject cardObj;
    public int cardCount;
    public int handCount;
    #endregion


    #region CardPositions
    [Header("Card Positions")]
    public GameObject displayPosSpot;
    [HideInInspector]
    public Vector3 displayPos;
    public GameObject startPos;
    public float distancing;
    #endregion
    [HideInInspector]
    public bool isDisplay;

    private void CreateCards()
    {
        for (int i = 0; i < cardCount; i++)
        {
            GameObject newCard = Instantiate(cardObj);
            CardState cS = newCard.GetComponent<CardState>();
            deck.Add(newCard);
            newCard.transform.position = startPos.transform.position;
        }
    }

    private void Start()
    {
        CreateCards();
    }

    private void Update()
    {
        if (!isDisplay)
        {
            displayCard();
        }
        if (isDisplay)
        {

        }

    }

    private void displayCard()
    {
        GameObject currentCard = deck[deck.Count - 1];
        currentCard.GetComponent<SpriteRenderer>().sortingOrder = handCount;
        CardState cS = currentCard.GetComponent<CardState>();
        displayPos = displayPosSpot.transform.position;
        Vector3 newPos = new Vector3(displayPos.x + (display.Count * distancing), displayPos.y, 0);
        if (cS.MoveCard(newPos, 3f))
        {
            display.Add(currentCard);
            deck.RemoveAt(deck.Count - 1);

            if(deck.Count == 0)
            {
                isDisplay = true;
            }
        }
    }




}
