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
        Debug.Log("in remove be id");
        for (int i = 0; i < graveYard.Count; i++)
        {
            Debug.Log("cards universallID: " + graveYard[i].universalCardID);
            if (graveYard[i].universalCardID == universalCardID) 
            {
                Debug.Log("a hit");
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
