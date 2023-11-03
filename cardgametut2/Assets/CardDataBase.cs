using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Card;

public class CardDataBase : MonoBehaviour
{
   
    public static List<Card> cardList = new List<Card>();


    void Awake()
    {
        cardList.Add(new Card(0, "None", 0, 0, 0, Resources.Load <Sprite>("1"), "None", new CADraw(0, "Draw 0 Cards")));
        cardList.Add(new Card(1, "Elf", 2, 1, 1, Resources.Load<Sprite>("1"), "Green", new CADraw(2, "Draw 2 Cards")));
        cardList.Add(new Card(2, "Dwarf", 3, 3, 3, Resources.Load<Sprite>("1"), "Red", new CAAddMana(1, "Add 1 max Mana")));
        cardList.Add(new Card(3, "Human", 5, 6, 5, Resources.Load<Sprite>("1"), "Blue", new CAAddMana(3, "Add 3 max Mana")));
        cardList.Add(new Card(4, "Demon", 1, 1, 1, Resources.Load<Sprite>("1"), "Purple", new CADraw(1, "Draw 1 Card")));
    }
}
