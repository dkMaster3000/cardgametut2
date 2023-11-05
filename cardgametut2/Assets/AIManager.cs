using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    //external objects
    public HandManager OpponentHandManager;

    public GameObject OpponentPlayArea;
    public GameObject PlayerPlayArea;

    public TurnSystem TurnSystem;

    //operational objects
    public ThisCard[] handCards = new ThisCard[] {};

    public ThisCard[] playedCards = new ThisCard[] {};
    public ThisCard[] playerPlayedCards = new ThisCard[] {};

    //phase flags
    public bool summonPhase = false;
    public bool battlePhase = false;
    public bool endPhase = false;

    void Start()
    {
        //load objects
        OpponentHandManager = GameObject.Find("OpponentHand").GetComponent<HandManager>();

        OpponentPlayArea = GameObject.Find("OpponentPlayArea");
        PlayerPlayArea = GameObject.Find("PlayerPlayArea");

        TurnSystem = GameObject.Find("TurnSystem").GetComponent<TurnSystem>();
    }

    //main function for AI
    public void PerformTurn()
    {
        summonPhase = true;
        //summon phase
        StartCoroutine(SummonCards());

        //battle phase

        //end phase
        StartCoroutine(EndTurn());
    }

    //summoning helper
    public IEnumerator SummonCards()
    {
        yield return new WaitUntil(() => summonPhase == true);

        handCards = OpponentHandManager.GetHandCards();

        //first summon first card
        ThisCard cardToSummon = Array.Find(handCards, element => element.CanBeSummoned() && element.cardName != "Reviver");

        if (cardToSummon)
        {
            yield return new WaitForSeconds(1);
            cardToSummon.AISummon();
            StartCoroutine(SummonCards());
        } else
        {
            summonPhase = false;
            battlePhase = true;
        }
    }

    public IEnumerator StartAttackPhase()
    {
        yield return new WaitUntil(() => battlePhase == true);
        yield return new WaitForSeconds(1);

        playedCards = OpponentPlayArea.GetComponentsInChildren<ThisCard>();
        playerPlayedCards = PlayerPlayArea.GetComponentsInChildren<ThisCard>();

        if( playedCards != null )
        {
            //cards are summoned
            //do attack
            if(playerPlayedCards != null)
            {
                //attack player cards
            } else
            {
                //attack player
            }
        } else
        {
            //no cards are summoned
            //end battle phase
            battlePhase = false;
            endPhase = true;
        }

    }

    //end turn
    public IEnumerator EndTurn()
    {
        yield return new WaitUntil(() => endPhase == true);
        yield return new WaitForSeconds(1);

        endPhase = false;
        TurnSystem.EndTurn();

    }




}
