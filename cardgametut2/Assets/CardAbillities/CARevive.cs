using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]

public class CARevive : CardAbillity
{
    public GraveYardManager GraveYardManager;

    public TurnSystem TurnSystem;


    public CARevive() : base("revive", "Revive 1 Monster")
    {

    }

    public override void Executable(GameObject gameObjectToInteract)
    {
        
        if (TurnSystem.isPlayerTurn)
        {
            GameState.targetingGraveYard = true;

            GraveYardManager = gameObjectToInteract.GetComponent<GraveYardManager>();
            GraveYardManager.ViewGraveYard();

        } 
        else
        {
            AIRevive AIRevive = GameObject.Find("AI").GetComponent<AIRevive>();
            AIRevive.ChooseToRevive();
        }
    }


}
