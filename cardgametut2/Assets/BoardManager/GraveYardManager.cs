using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveYardManager : MonoBehaviour
{

    public List<Card> graveYard = new List<Card>();

    public GameObject GraveYardViewer;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void BuryCard(Card card)
    {
        graveYard.Add(card);
    }

    public void RemoveByUniversalCardID(int universalCardID)
    {
        for (int i = 0; i < graveYard.Count; i++)
        {
            if (graveYard[i].universalCardID == universalCardID) 
            { 
                graveYard.RemoveAt(i);
            }
        }
    }

    public void ViewGraveYard()
    {
        GraveYardViewer.SetActive(true);
        GYVManager GYVManager = GraveYardViewer.GetComponent<GYVManager>();

        GYVManager.SetNewCards(graveYard, gameObject.name);
    }
}
