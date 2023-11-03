using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSpawner : MonoBehaviour
{
    public static GameObject Hand;
    public static GameObject OpponentPlayArea;
    public static GameObject PlayArea;
    public static GameObject CardDisplay;

    public enum CardTags
    {
        OpponentPlayedCard, PlayedCard, HandCard, GraveYardCard
    }

    public enum CardColors
    {
        Red, Blue, Green, Purple, None
    }

    void Start()
    {
        Hand = GameObject.Find("Hand");
        OpponentPlayArea = GameObject.Find("OpponentPlayArea");
        PlayArea = GameObject.Find("PlayArea");
    }

    public static Card GetCard(List<Card> Deck)
    {
        Card cardToReturn = Deck[Deck.Count - 1];
        Deck.RemoveAt(Deck.Count - 1);
        return cardToReturn;
    }

    public static GameObject CreateCard(GameObject CardPrefabToInstatiate, Card CardData, CardTags CardTag)
    {
        GameObject newCardObject = Instantiate(CardPrefabToInstatiate);
        ThisCard newCard = newCardObject.GetComponent<ThisCard>();

        newCardObject.tag = GetStringFromCardTags(CardTag);

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
        newCard.summoned = CardTag == CardTags.OpponentPlayedCard;
        newCard.dead = CardTag == CardTags.GraveYardCard;

        newCard.canAttack = false;
        newCard.targeting = false;
        newCard.targetingOpponent = false;

        newCard.frame.GetComponent<Image>().color = GetCardColor(CardData.color);

        newCardObject.GetComponent<MoveCard>().MoveToPosition(newCardObject, GetLocationFromCardTags(CardTag));

        return newCardObject;
    }

    public static Color32 GetCardColor(CardColors cardColor)
    {
        switch (cardColor)
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

    public static string GetStringFromCardTags(CardTags cardTag)
    {
        switch (cardTag)
        {
            case CardTags.OpponentPlayedCard:
                return "OpponentPlayedCard";
            case CardTags.HandCard:
                return "HandCard";
            case CardTags.GraveYardCard:
                return "GraveYardCard";
            default:
                return "Untagged"; 
        }
    }

    public static GameObject GetLocationFromCardTags(CardTags cardTag)
    {
        CardDisplay = GameObject.Find("CardDisplay");

        switch (cardTag)
        {
            case CardTags.OpponentPlayedCard:
                return OpponentPlayArea;
            case CardTags.HandCard:
                return Hand;
            case CardTags.GraveYardCard:
                return CardDisplay;
            case CardTags.PlayedCard:
                return PlayArea;
            default:
                return Hand;
        }
    }

}
