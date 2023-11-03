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

    public Sprite thisImage;

    public string color;

    //public CardAbillity cardAbillity;

    public CardAbillity[] cardAbillities;


    public Card()
    {

    }

    public Card(int Id, string CardName, int Cost, int Power, int Health, Sprite ThisImage, string Color, CardAbillity[] CardAbillities)
    {
        id = Id;
        cardName = CardName;
        cost = Cost;
        power = Power;
        health = Health;


        thisImage = ThisImage;

        color = Color;

        cardAbillities = CardAbillities;
    }
}
