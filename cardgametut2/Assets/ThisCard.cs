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

    public bool summoned;
    public GameObject battleZone;

    public TurnSystem TurnSystem;
    public PlayerDeck PlayerDeck;

    public int drawXcards;
    public int addXmaxMana;

    //new

    
    //public GameObject Target;
    public GameObject Opponent;
    public PlayerHP OpponentHP;

    public bool sleep;
    public bool canAttack;

    public static bool staticTargeting;
    public static bool staticTargetingOpponent;

    public bool targeting;
    public bool targetingOpponent;

    public bool onlyThisCardAttack;




    // Start is called before the first frame update
    void Start()
    {
        //default
        thisCard[0] = CardDataBase.cardList[thisId];

        Hand = GameObject.Find("Hand");

        cardBack = false;
        summoned = false;

        TurnSystem = GameObject.Find("TurnSystem").GetComponent<TurnSystem>();
        PlayerDeck = GameObject.Find("DeckArea").GetComponent<PlayerDeck>();
        OpponentHP = GameObject.Find("OpponentHP").GetComponent<PlayerHP>();

        if (this.tag == "HandCard")
        {
            thisCard[0] = PlayerDeck.GetCard();
            cardBack = false;
            this.tag = "Untagged";
            cardBackO.SetActive(cardBack);
        }

        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cost = thisCard[0].cost;
        power = thisCard[0].power;
        cardDescription = thisCard[0].cardDescription;

        drawXcards = thisCard[0].drawXcards;
        addXmaxMana = thisCard[0].addXmaxMana;

        thisSprite = thisCard[0].thisImage;

        nameText.text = " " + cardName;
        costText.text = " " + cost;
        powerText.text = " " + power;
        descriptionText.text = " " + cardDescription;

        thatImage.sprite = thisSprite;


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

        canAttack = false;
        sleep = true;

        Opponent = GameObject.Find("OpponentHP");
        targeting = false;
        targetingOpponent = false;

    }

    void Update()
    {
        //if(TurnSystem.isYourTurn == false && summoned == true)
        //{
        //    sleep = false;
        //    canAttack = false;
        //}

        //if(TurnSystem.isYourTurn && sleep == false && canAttack == false)
        //{
        //    canAttack = true;
        //} else
        //{
        //    canAttack=false;
        //}

        //targeting = staticTargeting;
        //targetingOpponent = staticTargetingOpponent;

        //if(targetingOpponent == true)
        //{
        //    Target = Opponent;
        //}
        //else
        //{
        //    Target = null;
        //}

        //if(targeting == true && targetingOpponent == true && onlyThisCardAttack == true)
        //{
        //    Attack();
        //}
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
        TurnSystem.IncreaseMaxMana(addXmaxMana);
        PlayerDeck.DrawCards(drawXcards);

    }

    public void BeReady()
    {
        sleep = false;
        canAttack = true;
        UpdateOutline();
    }

    public void BeExhausted()
    {
        sleep = true;
        canAttack = false;
        UpdateOutline();

    }

    public void UpdateOutline()
    {
        gameObject.GetComponent<Outline>().enabled = canAttack;

        if (targeting)
        {
            gameObject.GetComponent<Outline>().effectColor = Color.red;
        } else
        {
            gameObject.GetComponent<Outline>().effectColor = Color.yellow;
        }

    }

    //on initial drag
    public void Targeting()
    {
        if (!summoned || !canAttack) return;
        targeting = true;
        UpdateOutline();
    }

    public void StopTargeting()
    {
        if (!summoned || !canAttack) return;
        targeting = false;
        UpdateOutline();
    }

    //on hover over OpponetHP
    //public void UntargetOpponent()
    //{
    //    if(targeting == true)
    //    {
    //        Debug.Log("Untarget1");
    //        targetingOpponent = false;
    //    } 

    //}

    //public void TargetOpponent()
    //{
    //    if (targeting == true)
    //    {
    //        Debug.Log("Target1");
    //        targetingOpponent = true;
    //    }
    //}

    //on end drag
    public void Attack()
    {
        if (canAttack == true)
        {
            
                if (targetingOpponent)
                {
                    OpponentHP.currentHP -= power;                 
                    canAttack = false;
                    UpdateOutline();
            }

                //if (Target.name == "CardToHand(Clone)")
                //{
                //    canAttack = true;
                //}    
        }

        targeting = false;
    }



    //public void StartAttack()
    //{
    //    staticTargeting = true;
    //}

    //public void StoptAttack()
    //{
    //    staticTargeting = false;
    //}

    //public void OneCardAttack()
    //{
    //    onlyThisCardAttack = true;
    //}

    //public void OneCardAttackStop()
    //{
    //    onlyThisCardAttack = false;
    //}
}
