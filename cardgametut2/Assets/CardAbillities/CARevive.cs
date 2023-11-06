using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]

public class CARevive : CardAbillity
{
    public GraveYardManager GraveYardManager;

    public CARevive() : base("revive", "Revive 1 Monster")
    {

    }

    public override void Executable(GameObject gameObjectToInteract)
    {
        GraveYardManager = gameObjectToInteract.GetComponent<GraveYardManager>();
        GraveYardManager.ViewGraveYard();

        GameState.targetingGraveYard = true;
    }


}
