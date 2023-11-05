using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CardSpawner;
using Random = UnityEngine.Random;

public class PlayerDeck : MonoBehaviour
{

    public List<Card> deck = new List<Card>();
    //for shuffle helper
    public List<Card> container = new List<Card>();

    public int x;
    public int deckSize;

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    public GameObject CardToHand;

    public GameObject CardBack;
    public GameObject[] Clones;

    public bool isPlayerDeck = true;
    public CardTags handCardTag = CardTags.PlayerHandCard;

    public void Initialise()
    {
        isPlayerDeck = gameObject.tag == "PlayerDeck";
        handCardTag = isPlayerDeck ? CardTags.PlayerHandCard : CardTags.OpponentHandCard;

        x = 0;
        deckSize = 40;

        for (int i = 0; i < deckSize; i++)
        {
            x = Random.Range(1, CardDataBase.cardList.Count);
            Card cardTemplate = CardDataBase.cardList[x];

            //copy card from database
            Card nextAddedCard = new Card(cardTemplate.id, cardTemplate.cardName, cardTemplate.cost,
                cardTemplate.power, cardTemplate.health, cardTemplate.thisImage, cardTemplate.color, cardTemplate.cardAbillities);

            //give copied card universalID
            GameState.universalCardID++;
            nextAddedCard.universalCardID = GameState.universalCardID;

            deck[i] = nextAddedCard;
        }

        DrawCards(5);

        //For Test purpouse: create minions for Opponent 
        //CardSpawner.CreateCard(CardToHand, CardSpawner.GetCard(deck), CardTags.OpponentPlayedCard);
        //CardSpawner.CreateCard(CardToHand, CardSpawner.GetCard(deck), CardTags.OpponentPlayedCard);
        //CardSpawner.CreateCard(CardToHand, CardSpawner.GetCard(deck), CardTags.OpponentPlayedCard);
    }

    public void DrawCards(int cardsToDraw)
    {
        StartCoroutine(Draw(cardsToDraw));
        UpdateDeckVisual();
    }


    IEnumerator Draw(int x)
    {
        for (int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(0.1f);
            CardSpawner.CreateCard(CardToHand, CardSpawner.GetCard(deck), handCardTag);
        }

        //aimanager knowledge that it was drawn
        if(!isPlayerDeck && !AIManager.drawnThisTurn)
        {
            AIManager.drawnThisTurn = true;
        }

    }

    //has to be reworked if deck size increases
    public void UpdateDeckVisual()
    {
        if (deck.Count < 30)
        {
            cardInDeck1.SetActive(false);
        }
        if (deck.Count < 20)
        {
            cardInDeck2.SetActive(false);
        }
        if (deck.Count < 10)
        {
            cardInDeck3.SetActive(false);
        }
        if (deck.Count < 5)
        {
            cardInDeck4.SetActive(false);
        }
    }


    public void Shuffle()
    {
        for (int i = 0; i < deck.Count - 1; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deck.Count - 1);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }
        Instantiate(CardBack, transform.position, transform.rotation);
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
        Clones = GameObject.FindGameObjectsWithTag("Clone");

        foreach (GameObject Clone in Clones)
        {
            Destroy(Clone);
        }
    }
}
