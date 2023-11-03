using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{

    public int maxHP;
    public int currentHP;

    public Text hpText;
    public Image Health;

    public GameObject PlayArea;
    public GameState GameState;


    // Start is called before the first frame update
    void Start()
    {
        PlayArea = GameObject.Find("PlayArea");
        GameState = GameObject.Find("GameState").GetComponent<GameState>();

        maxHP = 20;
        currentHP = 20;

        UpdateText();
    }

    public void DealDamage(int damage)
    {
        currentHP -= damage;
        UpdateText();
    }

    public void Heal(int amount)
    {
        currentHP += amount;

        if (currentHP > maxHP) 
        {
            currentHP = maxHP;
        }
        UpdateText();
    }

    public void UpdateText()
    {
        hpText.text = currentHP + "/" + maxHP;
    }

    public void TargetOpponent()
    {
        GameState.LockTarget(gameObject);
    }

    public void UntargetOpponent()
    {
        GameState.LockTarget(null);
    }


}
