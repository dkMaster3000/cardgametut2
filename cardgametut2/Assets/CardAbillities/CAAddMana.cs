using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class CAAddMana : CardAbillity
{
    public int addXMana;

    public ManaManager ManaManager;



    public CAAddMana(int AddXMana) : base("addMana", "addMana")
    {
        addXMana = AddXMana;

        descriptionText = "Add " + AddXMana + " max Mana";
    }

    public override void Executable(GameObject gameObjectToInteract)
    {
        ManaManager = gameObjectToInteract.GetComponent<ManaManager>();
        ManaManager.IncreaseMaxMana(addXMana);

    }
}
