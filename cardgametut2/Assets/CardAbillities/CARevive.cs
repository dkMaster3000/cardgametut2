using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]

public class CARevive : CardAbillity
{
    public GraveYardManager GraveYardManager;

    public CARevive(string Description) : base("revive", Description)
    {

    }



    public override void Executable(GameObject gameObjectToInteract)
    {
        GraveYardManager = GameObject.Find("GraveYard").GetComponent<GraveYardManager>();
        GraveYardManager.ViewGraveYard();

        GameState.targetingGraveYard = true;


    }


}
