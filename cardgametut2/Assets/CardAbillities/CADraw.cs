using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class CADraw : CardAbillity
{
    public int drawXcards;

    public PlayerDeck PlayerDeck;



    public CADraw (int DrawXcards) : base("drawCards", "DrawXCards")
    {
        drawXcards = DrawXcards;

        descriptionText = "Draw " + DrawXcards + " Cards";
    }

    public override void Executable(GameObject gameObjectToInteract)
    {
        PlayerDeck = gameObjectToInteract.GetComponent<PlayerDeck>();
        PlayerDeck.DrawCards(drawXcards);
    }
}
