using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
   
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "None", 0, 0, "None", Resources.Load <Sprite>("1"), "None" ));
        cardList.Add(new Card(1, "Elf", 2, 1000, "It's a Baum", Resources.Load<Sprite>("1"), "Green" ));
        cardList.Add(new Card(2, "Dwarf", 3, 3000, "MountainDude", Resources.Load<Sprite>("1"), "Red" ));
        cardList.Add(new Card(3, "Human", 5, 6000, "Blabla", Resources.Load<Sprite>("1"), "Blue" ));
        cardList.Add(new Card(4, "Demon", 1, 1000, "Imp", Resources.Load<Sprite>("1"), "Purple" ));
    }
}
