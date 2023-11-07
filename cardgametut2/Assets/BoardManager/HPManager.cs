using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{

    public int maxHP;
    public int currentHP;

    public Text hpText;
    public Image Health;

    public GameState GameState;
    public EndGameManager EndGameManager;


    // Start is called before the first frame update
    void Start()
    {
        GameState = GameObject.Find("GameState").GetComponent<GameState>();
        EndGameManager = GameObject.Find("GameState").GetComponent<EndGameManager>();

        maxHP = 20;
        currentHP = 20;

        UpdateText();
    }

    public void DealDamage(int damage)
    {
        currentHP -= damage;
        UpdateText();

        if(currentHP <= 0)
        {
            EndGameManager.EndGame();
        }
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
