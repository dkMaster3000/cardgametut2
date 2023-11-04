using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static CardSpawner;

public class ThisCard : MonoBehaviour
{
    public Card cardData;
    public int thisId;

    public int id;
    public string cardName;
    public int cost;
    public int power;
    public int health;
    public string cardDescription;

    public CardAbillity[] cardAbillities;

    public Text nameText;
    public Text costText;
    public Text powerText;
    public Text healthText;
    public Text descriptionText;

    public Image thatImage;

    public Image frame;

    public bool cardBack;
    public GameObject cardBackO;

    public bool summoned;
    public bool dead;


    public bool isPlayerCard = true;
    public CardTags handCardTag = CardTags.PlayerHandCard;

    public GameObject PlayerGraveYard;
    public GameObject OpponentGraveYard;
    public GraveYardManager PlayerGraveYardManager;
    public GraveYardManager OpponentGraveYardManager;
    public GYVManager GYVManager;

    public GameObject ManaObject;
    public ManaManager ManaManager;

    public TurnSystem TurnSystem;

    public GameObject HPObject;
    public PlayerHP OpponentHP;

    public GameObject Deck;

    //Attack
    public GameObject Target;

    public GameState GameState;

    public bool canAttack;

    public bool targeting;
    public bool targetingOpponent;


    //Summoning Outline
    public HandManager HandManager;


    // Start is called before the first frame update
    void Start()
    {
        TurnSystem = GameObject.Find("TurnSystem").GetComponent<TurnSystem>();
        OpponentHP = GameObject.Find("OpponentHP").GetComponent<PlayerHP>();
        HandManager = GameObject.Find("PlayerHand").GetComponent<HandManager>();
        GameState = GameObject.Find("GameState").GetComponent<GameState>();

        if(gameObject.tag == CardSpawner.GetStringFromCardTags(CardTags.PlayerHandCard) || gameObject.tag == CardSpawner.GetStringFromCardTags(CardTags.PlayedCard))
        {
            isPlayerCard = true;
        } else
        {
            isPlayerCard = false;
        }

        if(isPlayerCard)
        {
            ManaObject = GameObject.Find("PlayerMana");
            HPObject = GameObject.Find("PlayerHP");
            Deck = GameObject.Find("PlayerDeckArea");
            PlayerGraveYard = GameObject.Find("PlayerGraveYard");
            OpponentGraveYard = GameObject.Find("OpponentGraveYard");
        } else
        {
            ManaObject = GameObject.Find("OpponentMana");
            HPObject = GameObject.Find("OpponentHP");
            Deck = GameObject.Find("OpponentDeckArea");
            PlayerGraveYard = GameObject.Find("OpponentGraveYard");
            OpponentGraveYard = GameObject.Find("PlayerGraveYard");

        }

        ManaManager = ManaObject.GetComponent<ManaManager>();

        PlayerGraveYardManager = PlayerGraveYard.GetComponent<GraveYardManager>();
        OpponentGraveYardManager = OpponentGraveYard.GetComponent<GraveYardManager>();

        if (gameObject.tag == CardSpawner.GetStringFromCardTags(CardTags.OpponentHandCard))
        {
            cardBack = true;
        }

        cardBackO.SetActive(cardBack);
        UpdateOutline();

    }

    public bool CanBeSummoned()
    {
        bool syncTurnOwner = TurnSystem.isPlayerTurn && isPlayerCard || !TurnSystem.isPlayerTurn && !isPlayerCard;

        if (syncTurnOwner && ManaManager.currentMana >= cost && summoned == false && dead == false)
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
        ManaManager.PayCost(cost);
        summoned = true;
        if(cardAbillities.Length > 0)
        {
            foreach (CardAbillity cardAbillity in cardAbillities)
            {

                switch (cardAbillity.abillityIdentfier){
                    case "charge":
                        canAttack = true;
                        break;
                    case "addMana":
                        cardAbillity.Executable(ManaObject);
                        break;
                    case "healPlayer":
                        cardAbillity.Executable(HPObject);
                        break;
                    case "drawCards":
                        cardAbillity.Executable(Deck);
                        break;
                    case "revive":
                        cardAbillity.Executable(PlayerGraveYard);
                        break;
                }

            }
        }

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
        PlayerGraveYardManager.BuryCard(cardData);
        Destroy(gameObject);
    }

    //Attack Handling
    //as attacker
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

    //as attack target
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


    //selection in GraveYard
    //on mouseclick
    public void Revive()
    {
        if(GameState.targetingGraveYard == true)
        {
            CardTags newCardTag = CardTags.PlayedCard;
            gameObject.tag = CardSpawner.GetStringFromCardTags(newCardTag);
            gameObject.GetComponent<MoveCard>().MoveToPosition(gameObject, CardSpawner.GetLocationFromCardTags(newCardTag));
            summoned = true;
            dead = false;

            PlayerGraveYardManager.RemoveByUniversalCardID(cardData.universalCardID);

            GameState.targetingGraveYard = false;
            GYVManager = GameObject.Find("GraveYardViewer").GetComponent<GYVManager>();
            GYVManager.CloseGYV();
            
        }

    }

}
