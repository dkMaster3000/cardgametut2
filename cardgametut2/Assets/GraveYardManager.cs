using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveYardScript : MonoBehaviour
{

    public List<Card> graveYard = new List<Card>();

    public GameObject GraveYardViewer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("GYManager cards: " + graveYard.Count);
    }

    public void BuryCard(Card card)
    {
        graveYard.Add(card);
    }

    public void ViewGraveYard()
    {
        GraveYardViewer.SetActive(true);
        GYVManager GYVManager = GraveYardViewer.GetComponent<GYVManager>();
        GYVManager.SetNewCards(graveYard);
        //GYVManager.cardsToDisplay = new List<Card>();
        //GYVManager.cardsToDisplay = graveYard;
    }
}
