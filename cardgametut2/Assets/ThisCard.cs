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
    public int health;
    public string cardDescription;

    public Text nameText;
    public Text costText;
    public Text powerText;
    public Text healthText;
    public Text descriptionText;

    public Sprite thisSprite;
    public Image thatImage;

    public Image frame;

    public bool cardBack;
    public GameObject cardBackO;

    public GameObject Hand;
    public GameObject GraveYard;
    public GameObject OpponentGraveYard;
    public GraveYardManager PlayerGraveYardScript;
    public GraveYardManager OpponentGraveYardScript;

    public GameObject GraveYardViewer;
    public GameObject CardDisplay;
    public GYVManager GYVManager;

    public bool summoned;
    public bool dead;
    public GameObject battleZone;

    public TurnSystem TurnSystem;
    public PlayerDeck PlayerDeck;

    public int drawXcards;
    public int addXmaxMana;



    //Attack
    public GameObject Target;
    public PlayerHP OpponentHP;
    public GameState GameState;

    public bool canAttack;

    public bool targeting;
    public bool targetingOpponent;


    //Summoning Outline
    public HandManager HandManager;


    // Start is called before the first frame update
    void Start()
    {
        //default
        thisCard[0] = CardDataBase.cardList[thisId];

        Hand = GameObject.Find("Hand");
        GraveYard = GameObject.Find("GraveYard");
        OpponentGraveYard = GameObject.Find("OpponentGraveYard");
        GraveYardViewer = GameObject.Find("GraveYardViewer");
        CardDisplay = GameObject.Find("CardDisplay");

        TurnSystem = GameObject.Find("TurnSystem").GetComponent<TurnSystem>();
        PlayerDeck = GameObject.Find("DeckArea").GetComponent<PlayerDeck>();
        OpponentHP = GameObject.Find("OpponentHP").GetComponent<PlayerHP>();
        HandManager = GameObject.Find("Hand").GetComponent<HandManager>();
        GameState = GameObject.Find("GameState").GetComponent<GameState>();
        PlayerGraveYardScript = GameObject.Find("GraveYard").GetComponent<GraveYardManager>();
        OpponentGraveYardScript = GameObject.Find("OpponentGraveYard").GetComponent<GraveYardManager>();


        cardBack = false;
        summoned = false;
        dead = false;

        if (tag == "HandCard")
        {
            thisCard[0] = PlayerDeck.GetCard();
            cardBack = false;
            tag = "Untagged";
            cardBackO.SetActive(cardBack);

            gameObject.GetComponent<MoveCard>().MoveToPosition(gameObject, Hand);
        }

        if (tag == "GraveYardCard")
        {
            GYVManager = GameObject.Find("GraveYardViewer").GetComponent<GYVManager>();
            thisCard[0] = GYVManager.GetCard();
            cardBack = false;
            dead = true;
            tag = "Untagged";
            cardBackO.SetActive(cardBack);

            gameObject.GetComponent<MoveCard>().MoveToPosition(gameObject, CardDisplay);
        }

        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cost = thisCard[0].cost;
        power = thisCard[0].power;
        health = thisCard[0].health;
        cardDescription = thisCard[0].cardDescription;

        drawXcards = thisCard[0].drawXcards;
        addXmaxMana = thisCard[0].addXmaxMana;

        thisSprite = thisCard[0].thisImage;

        nameText.text = " " + cardName;
        costText.text = " " + cost;
        powerText.text = " " + power;
        healthText.text = " " + health;
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

        targeting = false;
        targetingOpponent = false;

        UpdateOutline();

    }

    public bool CanBeSummoned()
    {
        if (TurnSystem.isYourTurn && TurnSystem.currentMana >= cost && summoned == false && dead == false)
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
        UpdateOutline();
        HandManager.UpdateHand();

    }

    //called in TurnSystem on EndTurn
    public void BeReady()
    {
        canAttack = true;
        UpdateOutline();
    }

    //called in TurnSystem on EndTurn
    public void BeExhausted()
    {
        canAttack = false;
        UpdateOutline();

    }

    public void UpdateOutline()
    {
        bool showOutline = canAttack;
        gameObject.GetComponent<Outline>().enabled = true;

        if (targeting)
        {
            gameObject.GetComponent<Outline>().effectColor = Color.red;
        } else
        {
            gameObject.GetComponent<Outline>().effectColor = Color.yellow;
        }

        if(CanBeSummoned())
        {
            gameObject.GetComponent<Outline>().effectColor = Color.green;
            showOutline = true;
        } 

        gameObject.GetComponent<Outline>().enabled = showOutline;

    }

    public void GetDamage(int damage)
    {
        health -= damage;
        UpdateHealth();
        if (health <= 0)
        {
            TriggerDeath();
        }
    }

    public void UpdateHealth()
    {
        healthText.text = " " + health;
    }

    public void TriggerDeath()
    {
        if (tag == "OpponentPlayedCard")
        {
            tag = "Untagged";        
            OpponentGraveYardScript.BuryCard(thisCard[0]);
            Destroy(gameObject);

        } else
        {
            PlayerGraveYardScript.BuryCard(thisCard[0]);
            Destroy(gameObject);

        }
    }

    //Attack Handling

    //on initial drag
    public void Targeting()
    {
        if (!summoned || !canAttack) return;
        targeting = true;
        GameState.targeting = true;
        UpdateOutline();
    }

    //on end drag
    public void StopTargeting()
    {
        if (!summoned || !canAttack) return;
        targeting = false;
        GameState.targeting = false;
        UpdateOutline();
    }


    //on end drag
    public void Attack()
    {
        if (canAttack == true)
        {
            if(Target != null)
            {
                if (Target.name == "OpponentHP")
                {
                    OpponentHP.DealDamage(power);
                }

                if (Target.name == "CardToHand(Clone)")
                {
                    ThisCard targetCard = Target.GetComponent<ThisCard>();
                    targetCard.GetDamage(power);
                    GetDamage(targetCard.power);
                }

                canAttack = false;
                UpdateOutline();
            }

              
        }
    }

    //on pointer enter
    public void TargetCard()
    {
        if(transform.parent.name == "OpponentPlayArea")
        {
            GameState.LockTarget(gameObject);
        }
        
    }

    //on pointer exit
    public void UntargetCard()
    {
        if (transform.parent.name == "OpponentPlayArea")
        {
            GameState.LockTarget(null);
        }
    }

}
