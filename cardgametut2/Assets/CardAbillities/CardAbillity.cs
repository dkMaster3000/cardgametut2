using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public abstract class CardAbillity
{
    //better with enums but okay for now
    public string abillityIdentfier;
    public string descriptionText;

    public CardAbillity(string AbillityIdentfier, string DescriptionText)
    {
        abillityIdentfier = AbillityIdentfier;
        descriptionText = DescriptionText;
    }

    public abstract void Executable();

}
