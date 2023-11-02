using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public abstract class CardAbillity
{
    public string abillityIdentfier;

    public CardAbillity(string AbillityIdentfier)
    {
        abillityIdentfier = AbillityIdentfier;
    }

    public abstract void Executable();

}
