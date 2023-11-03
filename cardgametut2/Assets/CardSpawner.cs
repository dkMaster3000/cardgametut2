using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSpawner : MonoBehaviour
{
    //tags
    public static string OpponentPlayedCard = "OpponentPlayedCard";
    public static string HandCard = "HandCard";
    public static string GraveYardCard = "GraveYardCard";

    public enum CardColors
    {
        Red, Blue, Green, Purple, None
    }

    void Start()
    {

    }

    public static Card GetCard(List<Card> Deck)
    {
        Card cardToReturn = Deck[Deck.Count - 1];
        Deck.RemoveAt(Deck.Count - 1);
        return cardToReturn;
    }

    public static GameObject CreateCard(GameObject CardPrefabToInstatiate, Card CardData, string CardTag, GameObject MoveTo)
    {
        GameObject newCardObject = Instantiate(CardPrefabToInstatiate);
        ThisCard newCard = newCardObject.GetComponent<ThisCard>();

        newCardObject.tag = CardTag;

        newCard.cardData = CardData;

        newCard.id = CardData.id;
        newCard.cardName = CardData.cardName;
        newCard.cost = CardData.cost;
        newCard.power = CardData.power;
        newCard.health = CardData.health;
        newCard.cardAbillities = CardData.cardAbillities;

        //get describtion trough all cardabillities
        if (newCard.cardAbillities.Length > 0)
        {
            foreach (CardAbillity cardAbillity in newCard.cardAbillities)
            {
                newCard.cardDescription += cardAbillity.descriptionText + "\n";
            }
        }
        else
        {
            newCard.cardDescription = "It's a Monster!";
        }

        newCard.nameText.text = " " + newCard.cardName;
        newCard.costText.text = " " + newCard.cost;
        newCard.powerText.text = " " + newCard.power;
        newCard.healthText.text = " " + newCard.health;
        newCard.descriptionText.text = " " + newCard.cardDescription;

        newCard.thatImage.sprite = CardData.thisImage;

        newCard.cardBack = false;
        newCard.summoned = CardTag == OpponentPlayedCard;
        newCard.dead = CardTag == GraveYardCard;

        newCard.canAttack = false;
        newCard.targeting = false;
        newCard.targetingOpponent = false;

        newCard.frame.GetComponent<Image>().color = GetCardColor(CardData.color);

        newCardObject.GetComponent<MoveCard>().MoveToPosition(newCardObject, MoveTo);

        return newCardObject;
    }

    public static Color32 GetCardColor(CardColors cardColors)
    {

        switch (cardColors)
        {
            case CardColors.Red:
                return new Color32(255, 0, 0, 255);
            case CardColors.Blue:
                return new Color32(0, 0, 255, 255);
            case CardColors.Green:
                return new Color32(0, 163, 108, 255);
            case CardColors.Purple:
                return new Color32(255, 0, 255, 255);
            case CardColors.None:
                return new Color32(255, 255, 255, 255);
            default:
                return new Color32(255, 255, 255, 255);
        }
        


    }

}
