using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CardSpawner;

public class ReviveCard : MonoBehaviour
{
    //pick on card to revive it
    //happens only for player

    ThisCard thisCard;
    Card cardData;

    public GameObject PlayerGraveYard;
    public GraveYardManager PlayerGraveYardManager;
    public GYVManager GYVManager;

    // Start is called before the first frame update
    void Start()
    {
        thisCard = gameObject.GetComponent<ThisCard>(); 
        cardData = thisCard.cardData;

        PlayerGraveYard = GameObject.Find("PlayerGraveYard");
        PlayerGraveYardManager = PlayerGraveYard.GetComponent<GraveYardManager>();
    }

    //selection in GraveYard
    //on mouseclick
    public void Revive()
    {
        if (GameState.targetingGraveYard == true)
        {
            CardSpawner.CreateCardTo(cardData, CardTags.PlayedCard);

            PlayerGraveYardManager.RemoveByUniversalCardID(cardData.universalCardID);

            GameState.targetingGraveYard = false;
            GYVManager = GameObject.Find("GraveYardViewer").GetComponent<GYVManager>();
            GYVManager.CloseGYV();

        }
    }
}
