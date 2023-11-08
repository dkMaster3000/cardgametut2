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

    public DeckManager PlayerDeckManager;
    public DeckManager OpponentDeckManager;

    public GameObject PlayerPlayArea;
    public GameObject OpponentPlayArea;

    public ManaManager PlayerManaManager;
    public ManaManager OpponentManaManager;

    //Summoning Outline
    public HandManager PlayerHandManager;
    public HandManager OpponentHandManager;

    public EndTurnButtonManager EndTurnButtonManager;

    public enum AttackModes
    {
        Ready, Exhausted
    }

    //AI
    AIManager AIManager;


    // Start is called before the first frame update
    void Start()
    {
        PlayerDeckManager = GameObject.Find("PlayerDeckArea").GetComponent<DeckManager>();
        OpponentDeckManager = GameObject.Find("OpponentDeckArea").GetComponent<DeckManager>();

        PlayerPlayArea = GameObject.Find("PlayerPlayArea");
        OpponentPlayArea = GameObject.Find("OpponentPlayArea");

        PlayerHandManager = GameObject.Find("PlayerHand").GetComponent<HandManager>();
        OpponentHandManager = GameObject.Find("OpponentHand").GetComponent<HandManager>();

        PlayerManaManager = GameObject.Find("PlayerMana").GetComponent<ManaManager>();
        OpponentManaManager = GameObject.Find("OpponentMana").GetComponent<ManaManager>();

        EndTurnButtonManager = GameObject.Find("EndTurnButton").GetComponent<EndTurnButtonManager>();

        AIManager = GameObject.Find("AI").GetComponent<AIManager>();

        isPlayerTurn = Random.value > 0.5f;
        playerTurn = isPlayerTurn ? 1 : 0;
        opponentTurn = isPlayerTurn ? 0: 1;

        PlayerDeckManager.Initialise();
        OpponentDeckManager.Initialise();

        PlayerManaManager.Initialise(isPlayerTurn);
        OpponentManaManager.Initialise(!isPlayerTurn);

        UpdateTurnText();
        EndTurnButtonManager.UpdateButtonText();

        if (!isPlayerTurn)
        {
            AIManager.PerformTurn();
        }
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

            PlayerDeckManager.DrawCards(1);

            //exhaus opponent creatures and prepare player creatures
            SwitchCanAttack(OpponentPlayArea, AttackModes.Exhausted);
            SwitchCanAttack(PlayerPlayArea, AttackModes.Ready);


        } else
        {
            opponentTurn += 1;

            OpponentManaManager.StartTurn();
            OpponentDeckManager.DrawCards(1);

            //exhaus player creatures and prepare opponent creatures
            SwitchCanAttack(PlayerPlayArea, AttackModes.Exhausted);
            SwitchCanAttack(OpponentPlayArea, AttackModes.Ready);

            AIManager.PerformTurn();

        }

        UpdateTurnText();
        EndTurnButtonManager.UpdateButtonText();
        PlayerHandManager.UpdateHand();
        OpponentHandManager.UpdateHand();
    }

    public void SwitchCanAttack(GameObject playArea, AttackModes attackMode)
    {
        ThisCard[] playedCards = playArea.GetComponentsInChildren<ThisCard>();

        foreach (ThisCard child in playedCards)
        {
            if(attackMode == AttackModes.Ready)
            {
                child.BeReady();
            }

            if(attackMode == AttackModes.Exhausted)
            {
                child.BeExhausted();
            }
            
        }
    }


}
