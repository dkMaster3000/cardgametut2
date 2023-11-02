using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{

    public int maxHP;
    public int currentHP;

    public Text hpText;
    public Image Health;

    public GameObject PlayArea;


    // Start is called before the first frame update
    void Start()
    {
        PlayArea = GameObject.Find("PlayArea");

        maxHP = 20;
        currentHP = 20;
    }

    public void DealDamage(int damage)
    {
        currentHP -= damage;
        UpdateText();
    }

    public void UpdateText()
    {
        hpText.text = currentHP + "/" + maxHP;
    }

    public void UntargetOpponent()
    {
        if (GameState.targeting)
        {
            GetTargetingCard().Target = null;
        }


    }

    public void TargetOpponent()
    {
        if (GameState.targeting)
        {
            GetTargetingCard().Target = gameObject;
        }
        
    }

    public ThisCard GetTargetingCard()
    {
        ThisCard[] playedCards = PlayArea.GetComponentsInChildren<ThisCard>();

        foreach (ThisCard child in playedCards)
        {
            if (child.targeting)
            {
                return child;
            }
        }

        return null;
    }
}
