using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Card;

public class CardDataBase : MonoBehaviour
{
   
    public static List<Card> cardList = new List<Card>();


    void Awake()
    {
        cardList.Add(new Card(0, "None", 0, 0, 0, Resources.Load<Sprite>("0"), CardSpawner.CardColors.None, new CardAbillity[]{ new CADraw(0) }));
        cardList.Add(new Card(1, "Ingeneer", 3, 1, 1, Resources.Load<Sprite>("1"), CardSpawner.CardColors.Green, new CardAbillity[] { new CADraw(2) }));
        cardList.Add(new Card(2, "Mayor", 3, 3, 3, Resources.Load<Sprite>("2"), CardSpawner.CardColors.Red, new CardAbillity[] { new CAAddMana(1) }));
        cardList.Add(new Card(3, "Rogue", 5, 4, 4, Resources.Load<Sprite>("3"), CardSpawner.CardColors.Blue, new CardAbillity[] { new CAAddMana(3) }));
        cardList.Add(new Card(4, "Ranger", 2, 1, 1, Resources.Load<Sprite>("4"), CardSpawner.CardColors.Purple, new CardAbillity[] { new CADraw(1) }));
        cardList.Add(new Card(5, "Junker", 3, 1, 1, Resources.Load<Sprite>("4"), CardSpawner.CardColors.Green, new CardAbillity[] { new CADraw(2), new CAAddMana(1) }));
        cardList.Add(new Card(6, "Pestdoktor", 6, 8, 8, Resources.Load<Sprite>("6"), CardSpawner.CardColors.Green, new CardAbillity[] { }));
        cardList.Add(new Card(7, "Priest", 2, 2, 2, Resources.Load<Sprite>("7"), CardSpawner.CardColors.Purple, new CardAbillity[] { new CAHealPlayer(5) }));
        cardList.Add(new Card(8, "HighPriest", 3, 1, 1, Resources.Load<Sprite>("8"), CardSpawner.CardColors.Blue, new CardAbillity[] { new CARevive()}));
        cardList.Add(new Card(9, "Minion", 1, 1, 1, Resources.Load<Sprite>("9"), CardSpawner.CardColors.Red, new CardAbillity[] { new CACharge()}));
    }
}
