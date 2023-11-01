using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
   
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "None", 0, 0, "None", Resources.Load <Sprite>("1"), "None", 0, 0 ));
        cardList.Add(new Card(1, "Elf", 2, 1, "Draw 2 Cards", Resources.Load<Sprite>("1"), "Green", 2, 0 ));
        cardList.Add(new Card(2, "Dwarf", 3, 3, "Add 1 max Mana", Resources.Load<Sprite>("1"), "Red", 0, 1));
        cardList.Add(new Card(3, "Human", 5, 6, "Add 3 max Mana", Resources.Load<Sprite>("1"), "Blue", 0, 3));
        cardList.Add(new Card(4, "Demon", 1, 1, "Draw 1 Card", Resources.Load<Sprite>("1"), "Purple", 1, 0));
    }
}
