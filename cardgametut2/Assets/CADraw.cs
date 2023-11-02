using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class CADraw : CardAbillity
{
    public int drawXcards;

    public PlayerDeck PlayerDeck;



    public CADraw (int DrawXcards) : base("drawCards")
    {
        drawXcards = DrawXcards;
    }

    public override void Executable()
    {
        PlayerDeck = GameObject.Find("DeckArea").GetComponent<PlayerDeck>();
        PlayerDeck.DrawCards(drawXcards);
    }
}
