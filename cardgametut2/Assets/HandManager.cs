using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{

    public void UpdateHand() {
        ThisCard[] handCards = gameObject.GetComponentsInChildren<ThisCard>();

        foreach (ThisCard child in handCards)
        {
            child.UpdateOutline();
        }
    }
}
