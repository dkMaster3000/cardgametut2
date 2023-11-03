using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static int universalCardID = 0;

    public static bool targeting = false;
    public static bool targetingGraveYard = false;

    public GameObject PlayArea;

    void Start()
    {
        PlayArea = GameObject.Find("PlayArea");
    }

    public ThisCard GetTargetingCard()
    {
        ThisCard[] playedCards = PlayArea.GetComponentsInChildren<ThisCard>();

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
