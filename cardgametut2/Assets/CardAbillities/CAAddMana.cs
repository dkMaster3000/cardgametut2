using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class CAAddMana : CardAbillity
{
    public int addXMana;

    public ManaManager ManaManager;



    public CAAddMana(int AddXMana, string Description) : base("addMana", Description)
    {
        addXMana = AddXMana;
    }

    public override void Executable(GameObject gameObjectToInteract)
    {
        ManaManager = gameObjectToInteract.GetComponent<ManaManager>();
        ManaManager.IncreaseMaxMana(addXMana);

    }
}
