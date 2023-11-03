using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class CAHealPlayer : CardAbillity
{
    public int healAmount;

    public PlayerHP PlayerHP;



    public CAHealPlayer(int HealAmount, string Description) : base("healPlayer", Description)
    {
        healAmount = HealAmount;
    }

    public override void Executable()
    {
        PlayerHP = GameObject.Find("HP").GetComponent<PlayerHP>();
        PlayerHP.Heal(healAmount);
    }
}
