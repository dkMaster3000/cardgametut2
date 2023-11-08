using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CardSpawner;

public class AIRevive : MonoBehaviour
{

    public GameObject OpponentPlayArea;

    public GraveYardManager OpponentGraveYardManager;

    void Start()
    {
        OpponentPlayArea = GameObject.Find("OpponentPlayArea");
        OpponentGraveYardManager = GameObject.Find("OpponentGraveYard").GetComponent<GraveYardManager>();
    }

    public void ChooseToRevive()
    {
        List<Card> graveYardCards = OpponentGraveYardManager.graveYard;
        int graveYardCardsCount = graveYardCards.Count;

        if (graveYardCardsCount > 0)
        {
            //for simlicity revive the first card
            Card firstCardInGraveYard = graveYardCards[0];

            CardSpawner.CreateCardTo(firstCardInGraveYard, CardTags.OpponentPlayedCard);

            OpponentGraveYardManager.RemoveByUniversalCardID(firstCardInGraveYard.universalCardID);
        }
    }

}
