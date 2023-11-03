using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{

    public static bool isPlayerTurn;
    public int playerTurn;
    public int opponentTurn;
    public Text turnText;

    //public int maxMana;
    //public int currentMana;
    //public Text manaText;

    public PlayerDeck PlayerDeck;
    public PlayerDeck OpponentDeck;

    public GameObject PlayArea;


    public ManaManager PlayerManaManager;
    public ManaManager OpponentManaManager;

    //Summoning Outline
    public HandManager HandManager;


    // Start is called before the first frame update
    void Start()
    {
        PlayerDeck = GameObject.Find("DeckArea").GetComponent<PlayerDeck>();
        OpponentDeck = GameObject.Find("OpponentDeckArea").GetComponent<PlayerDeck>();

        PlayArea = GameObject.Find("PlayArea");

        HandManager = GameObject.Find("PlayerHand").GetComponent<HandManager>();

        PlayerManaManager = GameObject.Find("PlayerMana").GetComponent<ManaManager>();
        OpponentManaManager = GameObject.Find("OpponentMana").GetComponent<ManaManager>();

        isPlayerTurn = true;
        playerTurn = 1;
        opponentTurn = 0;

        PlayerDeck.Initialise();
        OpponentDeck.Initialise();

        PlayerManaManager.Initialise(isPlayerTurn);
        OpponentManaManager.Initialise(!isPlayerTurn);

        UpdateTurnText();
    }

    public void UpdateTurnText()
    {
        if (isPlayerTurn == true)
        {
            turnText.text = "Your Turn";
        }
        else
        {
            turnText.text = "Opponent Turn";
        }

        //UpdateManaText();
    }

    //public void UpdateManaText()
    //{
    //    manaText.text = currentMana + "/" + maxMana;
    //}

    //public void IncreaseMaxMana(int x)
    //{
    //    maxMana += x;
    //    UpdateManaText();
    //}

    public void EndTurn()
    {
        isPlayerTurn = !isPlayerTurn;

        if (isPlayerTurn)
        {
            playerTurn += 1;

            PlayerManaManager.StartTurn();

            PlayerDeck.DrawCards(1);

            ThisCard[] playedCards = PlayArea.GetComponentsInChildren<ThisCard>();

            foreach (ThisCard child in playedCards)
            {
                child.BeReady();
            }


        } else
        {
            opponentTurn += 1;

            OpponentManaManager.StartTurn();

            ThisCard[] playedCards = PlayArea.GetComponentsInChildren<ThisCard>();

            foreach (ThisCard child in playedCards)
            {
                child.BeExhausted();
            }
            
        }

        UpdateTurnText();
        HandManager.UpdateHand();
    }


}
