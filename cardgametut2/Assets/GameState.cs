using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static int universalCardID = 0;

    public static bool targeting = false;
    public static bool targetingGraveYard = false;

    public GameObject PlayerPlayArea;

    void Start()
    {
        PlayerPlayArea = GameObject.Find("PlayerPlayArea");
    }

    public ThisCard GetTargetingCard()
    {
        ThisCard[] playedCards = PlayerPlayArea.GetComponentsInChildren<ThisCard>();

        foreach (ThisCard child in playedCards)
        {
            if (child.targeting)
            {
                return child;
            }
        }

        return null;
    }

    public void LockTarget(GameObject target)
    {
        if (GameState.targeting)
        {
            GetTargetingCard().Target = target;
        }
    }

}
