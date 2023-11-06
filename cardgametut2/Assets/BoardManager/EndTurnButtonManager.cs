using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnButtonManager : MonoBehaviour
{
    public TurnSystem TurnSystem;

    public Text buttonText;

    public string displayString = "";
    public string endTurnString = "End Turn";
    public string waitString = "Wait";


    // Start is called before the first frame update
    void Start()
    {
        TurnSystem = GameObject.Find("TurnSystem").GetComponent<TurnSystem>();
    }

    public void UpdateButtonText()
    {
        if(TurnSystem.isPlayerTurn)
        {
            displayString = endTurnString;
            gameObject.GetComponent<Image>().color = new Color32(0, 163, 108, 255);
        } 
        else
        {
            displayString = waitString;
            gameObject.GetComponent<Image>().color = new Color32(97, 97, 97, 255);
        }

        buttonText.text = displayString;
    }

    public void OnClick()
    {
        if (TurnSystem.isPlayerTurn)
        {
            TurnSystem.EndTurn();
        }
    }


}
