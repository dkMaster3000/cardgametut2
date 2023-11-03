using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{

    public int maxMana = 0;
    public int currentMana = 0;
    public Text manaText;


    public void Initialise(bool isMyTurn)
    {

        if (isMyTurn)
        {
            maxMana = 1;
            currentMana = 1;
        } else
        {
            maxMana = 0;
            currentMana = 0;
        }

        UpdateManaText();
    }

    public void UpdateManaText()
    {
        manaText.text = currentMana + "/" + maxMana;
    }

    public void IncreaseMaxMana(int x)
    {
        maxMana += x;
        UpdateManaText();
    }

    public void StartTurn()
    {
        maxMana += 1;
        currentMana = maxMana;

        UpdateManaText();
    }


}
