using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GYVManager : MonoBehaviour
{

    public GameObject GraveYardViewer;

    public List<Card> cardsToDisplay = new List<Card>();

    public GameObject GraveYardCard;

    public GameObject CardDisplay;

    public Text GYVTitle;

    // Start is called before the first frame update
    void Start()
    {
        CardDisplay = GameObject.Find("CardDisplay");
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

    public Card GetCard()
    {
        Card cardToReturn = cardsToDisplay[cardsToDisplay.Count - 1];
        cardsToDisplay.RemoveAt(cardsToDisplay.Count - 1);
        return cardToReturn;
    }

    public void SetNewCards(List<Card> CardsToDisplay, string Title)
    {
        cardsToDisplay = new List<Card>(CardsToDisplay);
        GYVTitle.text = Title;
        DisplayCards();
    }

    public void DisplayCards()
    {
        foreach (Card card in cardsToDisplay)
        {
            Instantiate(GraveYardCard, transform.position, transform.rotation);
        }
    }
}
