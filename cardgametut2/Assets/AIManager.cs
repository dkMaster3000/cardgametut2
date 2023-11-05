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
        //summon phase
        SummonCards();

        //battle phase

        //end phase
        TurnSystem.EndTurn();
    }

    //summoning helper
    public void SummonCards()
    {
        handCards = OpponentHandManager.GetHandCards();

        //first summon first card
        ThisCard cardToSummon = Array.Find(handCards, element => element.CanBeSummoned() && element.cardName != "Reviver");

        if (cardToSummon)
        {
            //cardToSummon.AISummon();
            StartCoroutine(DelayedSummon(0.5f, cardToSummon));
            //SummonCards();
        } else
        {
            return;
        }

        
    }

    //visual gap
    public IEnumerator DelayedSummon(float x, ThisCard cardToSummon)
    {
            yield return new WaitForSeconds(x);
            cardToSummon.AISummon();
            //SummonCards();

    }




}
