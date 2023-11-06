using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class CADraw : CardAbillity
{
    public int drawXcards;


    public CADraw (int DrawXcards) : base("drawCards", "DrawXCards")
    {
        drawXcards = DrawXcards;

        descriptionText = "Draw " + DrawXcards + " Cards";
    }

    public override void Executable(GameObject gameObjectToInteract)
    {
        DeckManager PlayerDeck = gameObjectToInteract.GetComponent<DeckManager>();
        PlayerDeck.DrawCards(drawXcards);
    }
}
