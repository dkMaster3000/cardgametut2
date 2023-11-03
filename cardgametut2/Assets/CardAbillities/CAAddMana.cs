using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class CAAddMana : CardAbillity
{
    public int addXMana;

    public TurnSystem TurnSystem;



    public CAAddMana(int AddXMana, string Description) : base("addMana", Description)
    {
        addXMana = AddXMana;
    }

    public override void Executable()
    {
        TurnSystem = GameObject.Find("TurnSystem").GetComponent<TurnSystem>();
        //TurnSystem.IncreaseMaxMana(addXMana);
    }
}
