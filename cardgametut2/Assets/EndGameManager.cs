using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    public GameObject EndGameScreen;

    public HPManager PlayerHP;
    public HPManager OpponentHP;

    public Text resultText;
    public Text winsText;
    public Text losesText;

    public string result;

    public int storedWins;
    public int storedLosts;
    public string storingWin = "storingWin";
    public string storingLoose = "storingLoose";


    void Start()
    {
        PlayerHP = GameObject.Find("PlayerHP").GetComponent<HPManager>();
        OpponentHP = GameObject.Find("OpponentHP").GetComponent<HPManager>();

        storedWins = PlayerPrefs.GetInt(storingWin);
        storedLosts = PlayerPrefs.GetInt(storingLoose);
    }


    public void EndGame()
    {
        EndGameScreen.SetActive(true);

        if (PlayerHP.currentHP <= 0)
        {
            result = "You Lose!";
            storedLosts++;
            PlayerPrefs.SetInt(storingLoose, storedLosts);
        } else
        {
            result = "You Win!";
            storedWins++;
            PlayerPrefs.SetInt(storingWin, storedWins);
        }

        resultText.text = result;
        losesText.text = "Lost: " + storedLosts;
        winsText.text = "Won: " + storedWins;

    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
