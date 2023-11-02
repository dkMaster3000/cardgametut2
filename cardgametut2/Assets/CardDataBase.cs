using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Card;

public class CardDataBase : MonoBehaviour
{
   
    public static List<Card> cardList = new List<Card>();


    void Awake()
    {

        cardList.Add(new Card(0, "None", 0, 0, 0, "None", Resources.Load <Sprite>("1"), "None", 0, 0, new CADraw(0)));
        cardList.Add(new Card(1, "Elf", 2, 1, 1, "Draw 2 Cards", Resources.Load<Sprite>("1"), "Green", 2, 0, new CADraw(2)));
        cardList.Add(new Card(2, "Dwarf", 3, 3, 3, "Add 1 max Mana", Resources.Load<Sprite>("1"), "Red", 0, 1, new CADraw(0)));
        cardList.Add(new Card(3, "Human", 5, 6, 5, "Add 3 max Mana", Resources.Load<Sprite>("1"), "Blue", 0, 3, new CADraw(0)));
        cardList.Add(new Card(4, "Demon", 1, 1, 1, "Draw 1 Card", Resources.Load<Sprite>("1"), "Purple", 1, 0, new CADraw(1)));
    }
}
