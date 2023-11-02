using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Card
{
    public int id;
    public string cardName;
    public int cost;
    public int power;
    public int health;
    public string cardDescription;

    public int drawXcards;
    public int addXmaxMana;

    public Sprite thisImage;

    public string color;

    public CardAbillity cardAbillity;


    public Card()
    {

    }

    public Card(int Id, string CardName, int Cost, int Power, int Health, string CardDescription, Sprite ThisImage, string Color, int DrawXcards, int AddXmaxMana, CardAbillity CardAbillity)
    {
        id = Id;
        cardName = CardName;
        cost = Cost;
        power = Power;
        health = Health;
        cardDescription = CardDescription;
        addXmaxMana = AddXmaxMana;

        drawXcards = DrawXcards;

        thisImage = ThisImage;

        color = Color;

        cardAbillity = CardAbillity;
    }
}
