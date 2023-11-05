using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{

    public void UpdateHand() {
        ThisCard[] handCards = GetHandCards();

        foreach (ThisCard child in handCards)
        {
            child.UpdateOutline();
        }
    }

    public ThisCard[] GetHandCards ()
    {
        return gameObject.GetComponentsInChildren<ThisCard>();
    }
}
