using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class CAHealPlayer : CardAbillity
{
    public int healAmount;

    public CAHealPlayer(int HealAmount) : base("healPlayer", "healPlayer")
    {
        healAmount = HealAmount;

        descriptionText = "Heal " + HealAmount + " by Player";
    }

    public override void Executable(GameObject gameObjectToInteract)
    {
        HPManager PlayerHP = gameObjectToInteract.GetComponent<HPManager>();
        PlayerHP.Heal(healAmount);
    }
}
