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

    // Update is called once per frame
    void Update()
    {

        hpText.text = currentHP + "/" + maxHP;
    }

    public void UntargetOpponent()
    {
        ThisCard[] playedCards = PlayArea.GetComponentsInChildren<ThisCard>();

        foreach (ThisCard child in playedCards)
        {
            if (child.targeting)
            {
                child.targetingOpponent = false;
            }
        }

    }

    public void TargetOpponent()
    {
        ThisCard[] playedCards = PlayArea.GetComponentsInChildren<ThisCard>();
      
        foreach (ThisCard child in playedCards)
        {
           if (child.targeting)
            {
                child.targetingOpponent = true;
            }
        }
    }
}
