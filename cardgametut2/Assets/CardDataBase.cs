using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Card;

public class CardDataBase : MonoBehaviour
{
   
    public static List<Card> cardList = new List<Card>();


    void Awake()
    {
        cardList.Add(new Card(0, "None", 0, 0, 0, Resources.Load<Sprite>("1"), CardSpawner.CardColors.None, new CardAbillity[]{ new CADraw(0, "Draw 0 Cards") }));
        cardList.Add(new Card(1, "Elf", 2, 1, 1, Resources.Load<Sprite>("1"), CardSpawner.CardColors.Green, new CardAbillity[] { new CADraw(2, "Draw 2 Cards") }));
        cardList.Add(new Card(2, "Dwarf", 3, 3, 3, Resources.Load<Sprite>("1"), CardSpawner.CardColors.Red, new CardAbillity[] { new CAAddMana(1, "Add 1 max Mana") }));
        cardList.Add(new Card(3, "Human", 5, 6, 5, Resources.Load<Sprite>("1"), CardSpawner.CardColors.Blue, new CardAbillity[] { new CAAddMana(3, "Add 3 max Mana") }));
        cardList.Add(new Card(4, "Demon", 1, 1, 1, Resources.Load<Sprite>("1"), CardSpawner.CardColors.Purple, new CardAbillity[] { new CADraw(1, "Draw 1 Card") }));
        cardList.Add(new Card(5, "Highelf", 2, 1, 1, Resources.Load<Sprite>("1"), CardSpawner.CardColors.Green, new CardAbillity[] { new CADraw(2, "Draw 2 Cards"), new CAAddMana(1, "Add 1 max Mana") }));
        cardList.Add(new Card(6, "Oger", 6, 8, 8, Resources.Load<Sprite>("1"), CardSpawner.CardColors.Green, new CardAbillity[] { }));
        cardList.Add(new Card(7, "Priest", 2, 2, 2, Resources.Load<Sprite>("1"), CardSpawner.CardColors.Purple, new CardAbillity[] { new CAHealPlayer(5, "Heal 5 by Player") }));
        cardList.Add(new Card(8, "Reviver", 2, 1, 1, Resources.Load<Sprite>("1"), CardSpawner.CardColors.Blue, new CardAbillity[] { new CARevive("Revive 1 Monster")}));
    }
}
