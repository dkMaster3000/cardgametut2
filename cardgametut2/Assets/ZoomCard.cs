using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using static CardSpawner;

public class ZoomCard : MonoBehaviour
{
    public GameObject Canvas;
    private GameObject zoomCard;

    void Start()
    {
        Canvas = GameObject.Find("Canvas");
    }

    //OnHoverEnter() is called by the Pointer Enter event in the Event Trigger component attached to this gameobject
    public void OnHoverEnter()
    {
        //should only be available for player hand cards
        if(tag == GetStringFromCardTags(CardTags.PlayerHandCard))
        {
            ThisCard thisCard = this.GetComponent<ThisCard>();

            //create a copy of the card
            zoomCard = CardSpawner.CreateCard(thisCard.cardData, CardSpawner.CardTags.PlayerHandCard);

            //make the card a child of the Canvas so that it is rendered on top of everything else
            zoomCard.transform.SetParent(Canvas.transform, true);

            //change the Position
            zoomCard.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 400);

            //make the card bigger
            zoomCard.transform.localScale = new Vector2(3, 3);
        }
    }

    //OnHoverExit() is called by the Pointer Exit event (as well as Begin Drag) in the Event Trigger component attached to this gameobject
    public void OnHoverExit()
    {
        //if a card is there it should be destroyed
        if (zoomCard)
            Destroy(zoomCard);

    }

}
