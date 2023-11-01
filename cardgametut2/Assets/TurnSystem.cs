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


    // Start is called before the first frame update
    void Start()
    {
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

    public void EndTurn()
    {
        isYourTurn = !isYourTurn;

        if (isYourTurn)
        {
            yourTurn += 1;

            maxMana += 1;
            currentMana = maxMana;
        } else
        {
            opponentTurn += 1;
        }

        UpdateTurnText();
    }
}
