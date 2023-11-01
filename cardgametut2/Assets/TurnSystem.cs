using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{

    public bool isYourTurn;
    public int yourTurn;
    public int opponentTurn;
    public Text turnText;

    public int maxMana;
    public int currentMana;
    public Text manaText;

    public PlayerDeck PlayerDeck;
    public GameObject PlayArea;


    // Start is called before the first frame update
    void Start()
    {
        PlayerDeck = GameObject.Find("DeckArea").GetComponent<PlayerDeck>();
        PlayArea = GameObject.Find("PlayArea");

        isYourTurn = true;
        yourTurn = 1;
        opponentTurn = 0;

        maxMana = 1;
        currentMana = 1;

        UpdateTurnText();
    }

    public void UpdateTurnText()
    {
        if (isYourTurn == true)
        {
            turnText.text = "Your Turn";
        }
        else
        {
            turnText.text = "Opponent Turn";
        }

        UpdateManaText();
    }

    public void UpdateManaText()
    {
        manaText.text = currentMana + "/" + maxMana;
    }

    public void IncreaseMaxMana(int x)
    {
        maxMana += x;
        UpdateManaText();
    }

    public void EndTurn()
    {
        isYourTurn = !isYourTurn;

        if (isYourTurn)
        {
            yourTurn += 1;

            maxMana += 1;
            currentMana = maxMana;

            PlayerDeck.DrawCards(1);

            ThisCard[] playedCards = PlayArea.GetComponentsInChildren<ThisCard>();

            foreach (ThisCard child in playedCards)
            {
                child.BeReady();
            }


        } else
        {
            opponentTurn += 1;

            ThisCard[] playedCards = PlayArea.GetComponentsInChildren<ThisCard>();

            foreach (ThisCard child in playedCards)
            {
                child.BeExhausted();
            }
            
        }

        UpdateTurnText();
    }


}
