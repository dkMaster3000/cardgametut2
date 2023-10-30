using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
   
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "None", 0, 0, "None"));
        cardList.Add(new Card(1, "Elf", 2, 1000, "It's a Baum"));
        cardList.Add(new Card(2, "Dwarf", 3, 3000, "MountainDude"));
        cardList.Add(new Card(3, "Human", 5, 6000, "Blabla"));
        cardList.Add(new Card(4, "Demon", 1, 1000, "Imp"));
    }
}
