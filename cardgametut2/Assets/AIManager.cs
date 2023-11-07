using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static TurnSystem;

public class AIManager : MonoBehaviour
{
    //external objects
    public HandManager OpponentHandManager;

    public GameObject OpponentPlayArea;
    public GameObject PlayerPlayArea;

    public GameObject PlayerHPObject;

    public TurnSystem TurnSystem;

    //operational objects
    public ThisCard[] handCards = new ThisCard[] {};

    //phase flags
    public bool initialized = false;
    public static bool drawnThisTurn = false;
    public bool drawPhase = false;
    public bool summonPhase = false;
    public bool battlePhase = false;
    public bool cardIsAttacking = false;
    public bool endPhase = false;

    void Start()
    {
        //load objects
        OpponentHandManager = GameObject.Find("OpponentHand").GetComponent<HandManager>();

        OpponentPlayArea = GameObject.Find("OpponentPlayArea");
        PlayerPlayArea = GameObject.Find("PlayerPlayArea");

        PlayerHPObject = GameObject.Find("PlayerHP");

        TurnSystem = GameObject.Find("TurnSystem").GetComponent<TurnSystem>();
    }

    //main function for AI
    public void PerformTurn()
    {
        //drawPhase
        StartCoroutine(WaitUntilDrawn());

        //summon phase
        StartCoroutine(SummonCards());

        //battle phase
        StartCoroutine(StartBattlePhase());

        //end phase
        StartCoroutine(EndTurn());
    }

    //always waits for drawn cards, especialy important in initialization
    //should be triggert in drawablitties
    public IEnumerator WaitUntilDrawn()
    {
        yield return new WaitUntil(() => drawnThisTurn == true);
        drawnThisTurn = false;
        summonPhase = true;
    }

    //summoning helper
    public IEnumerator SummonCards()
    {
        yield return new WaitUntil(() => summonPhase == true);

        handCards = OpponentHandManager.GetHandCards();

        //first summon first card
        ThisCard cardToSummon = Array.Find(handCards, element => element.CanBeSummoned());

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

    public IEnumerator StartBattlePhase()
    {
        yield return new WaitUntil(() => battlePhase == true);
        yield return new WaitForSeconds(1);

        //get all cards that can attack in a list
        ThisCard[] preparedCards = null;
        ThisCard[] playedCards = OpponentPlayArea.GetComponentsInChildren<ThisCard>();
        if ( playedCards != null ) preparedCards = playedCards.Where(c => c.canAttack).ToArray();


        if (preparedCards != null )
        {
            //cards are summoned and can attack
            foreach (ThisCard card in preparedCards)
            {
                yield return new WaitForSeconds(0.5f);
                yield return new WaitUntil(() => cardIsAttacking == false);
                StartCoroutine(PerformAttack(card));
            }

            endPhase = true;


        } else
        {
            //no cards are summoned
            //end battle phase
            battlePhase = false;
            endPhase = true;
        }

    }

    public IEnumerator PerformAttack(ThisCard attackingCard)
    {
        cardIsAttacking = true;
        attackingCard.Targeting();
        yield return new WaitForSeconds(0.5f);


        //all cards from player
        ThisCard[] playerPlayedCards = PlayerPlayArea.GetComponentsInChildren<ThisCard>();

        //do attack
        if (playerPlayedCards.Length > 0)
        {
            //attack player cards (in order to simplify
            attackingCard.Target = PlayerPlayArea.transform.GetChild(0).gameObject;
        }
        else
        {
            //attack player
            attackingCard.Target = PlayerHPObject;
        }

        attackingCard.Attack();

        cardIsAttacking = false;
    }

    //end turn
    public IEnumerator EndTurn()
    {
        yield return new WaitUntil(() => endPhase == true);
        yield return new WaitForSeconds(1);

        drawnThisTurn = false;
        endPhase = false;
        TurnSystem.EndTurn();
    }

}
