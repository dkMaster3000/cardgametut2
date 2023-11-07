using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using static CardSpawner;

public class GYVManager : MonoBehaviour
{

    public GameObject GraveYardViewer;

    public List<Card> cardsToDisplay = new List<Card>();

    public GameObject CardToHand;

    public GameObject CardDisplay;

    public Text GYVTitle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CloseGYV()
    {
        int childrenNumber = CardDisplay.transform.childCount;
        for (int i = 0; i < childrenNumber; i++)
        {
            GameObject child = CardDisplay.transform.GetChild(i).gameObject;
            Destroy(child);
        }
        GraveYardViewer.SetActive(false);
    }

    public void SetNewCards(List<Card> CardsToDisplay, string Title)
    {
        cardsToDisplay = new List<Card>(CardsToDisplay);
        GYVTitle.text = Title;
        DisplayCards();
    }

    public void DisplayCards()
    {
        CardDisplay = GameObject.Find("CardDisplay");

        int cardCount = cardsToDisplay.Count;
        for(int i = 0; i < cardCount; i++)
        {
            CardSpawner.CreateCardTo(CardSpawner.GetCard(cardsToDisplay), CardTags.GraveYardCard);
        }
    }
}
