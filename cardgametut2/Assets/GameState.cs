using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameState : MonoBehaviour
{
    public static bool targeting = false;

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
