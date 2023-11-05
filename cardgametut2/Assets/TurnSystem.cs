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

    public PlayerDeck PlayerDeck;
    public PlayerDeck OpponentDeck;

    public GameObject PlayerPlayArea;


    public ManaManager PlayerManaManager;
    public ManaManager OpponentManaManager;

    //Summoning Outline
    public HandManager PlayerHandManager;
    public HandManager OpponentHandManager;

    //AI
    AIManager AIManager;


    // Start is called before the first frame update
    void Start()
    {
        PlayerDeck = GameObject.Find("PlayerDeckArea").GetComponent<PlayerDeck>();
        OpponentDeck = GameObject.Find("OpponentDeckArea").GetComponent<PlayerDeck>();

        PlayerPlayArea = GameObject.Find("PlayerPlayArea");

        PlayerHandManager = GameObject.Find("PlayerHand").GetComponent<HandManager>();
        OpponentHandManager = GameObject.Find("OpponentHand").GetComponent<HandManager>();

        PlayerManaManager = GameObject.Find("PlayerMana").GetComponent<ManaManager>();
        OpponentManaManager = GameObject.Find("OpponentMana").GetComponent<ManaManager>();

        AIManager = GameObject.Find("AI").GetComponent<AIManager>();

        //isPlayerTurn = Random.value > 0.5f;
        isPlayerTurn = false;
        playerTurn = isPlayerTurn ? 1 : 0;
        opponentTurn = isPlayerTurn ? 0: 1;

        PlayerDeck.Initialise();
        OpponentDeck.Initialise();

        PlayerManaManager.Initialise(isPlayerTurn);
        OpponentManaManager.Initialise(!isPlayerTurn);

        UpdateTurnText();

        if (!isPlayerTurn)
        {
            StartCoroutine(DelayedAIPerform(1.5f));
        }
    }

    public IEnumerator DelayedAIPerform(float x)
    {
        yield return new WaitForSeconds(x);
        AIManager.PerformTurn();

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

    }



    public void EndTurn()
    {
        isPlayerTurn = !isPlayerTurn;

        if (isPlayerTurn)
        {
            playerTurn += 1;

            PlayerManaManager.StartTurn();

            PlayerDeck.DrawCards(1);

            ThisCard[] playedCards = PlayerPlayArea.GetComponentsInChildren<ThisCard>();

            foreach (ThisCard child in playedCards)
            {
                child.BeReady();
            }


        } else
        {
            opponentTurn += 1;

            OpponentManaManager.StartTurn();
            OpponentDeck.DrawCards(1);

            ThisCard[] playedCards = PlayerPlayArea.GetComponentsInChildren<ThisCard>();

            foreach (ThisCard child in playedCards)
            {
                child.BeExhausted();
            }

            StartCoroutine(DelayedAIPerform(0.5f));


        }

        UpdateTurnText();
        PlayerHandManager.UpdateHand();
        OpponentHandManager.UpdateHand();
    }


}
