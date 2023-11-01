using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
{
    //why list?
    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;

    public Text nameText;
    public Text costText;
    public Text powerText;
    public Text descriptionText;

    public Sprite thisSprite;
    public Image thatImage;

    public Image frame;

    public bool cardBack;
    public GameObject cardBackO;

    public GameObject Hand;

    public int numberOfCardsInDeck;

    public bool summoned;
    public GameObject battleZone;

    public TurnSystem TurnSystem;


    // Start is called before the first frame update
    void Start()
    {
        thisCard[0] = CardDataBase.cardList[thisId];

        Hand = GameObject.Find("Hand");

        numberOfCardsInDeck = PlayerDeck.deckSize;
        cardBack = false;
        summoned = false;

        TurnSystem = GameObject.Find("TurnSystem").GetComponent<TurnSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.parent == Hand.transform.parent)
        {
            cardBack = false;
        }

        //all in start?
        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cost = thisCard[0].cost;
        power = thisCard[0].power;
        cardDescription = thisCard[0].cardDescription;

        thisSprite = thisCard[0].thisImage;

        nameText.text = " " + cardName;
        costText.text = " " + cost;
        powerText.text = " " + power;
        descriptionText.text = " " + cardDescription;

        thatImage.sprite  = thisSprite;


        if (thisCard[0].color == "Red")
        {
            frame.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
        if (thisCard[0].color == "Green")
        {
            frame.GetComponent<Image>().color = new Color32(0, 163, 108, 255);
        }
        if (thisCard[0].color == "Blue")
        {
            frame.GetComponent<Image>().color = new Color32(0, 0, 255, 255);
        }
        if (thisCard[0].color == "Purple")
        {
            frame.GetComponent<Image>().color = new Color32(255, 0, 255, 255);
        }

        if (thisCard[0].color == "None")
        {
            frame.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }

       
         
       
        if(this.tag == "HandCard")
        {
            thisCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";
            cardBackO.SetActive(cardBack);
        }

    }

    public bool CanBeSummoned()
    {
        if (TurnSystem.currentMana >= cost && summoned == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Summon()
    {
        TurnSystem.currentMana -= cost;
        TurnSystem.UpdateManaText();
        summoned = true;
    }
}
