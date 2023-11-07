using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Text winsText;
    public Text losesText;

    public string storingWin = "storingWin";
    public string storingLoose = "storingLoose";

    void Start()
    {
        losesText.text = "Lost: " + PlayerPrefs.GetInt(storingLoose); ;
        winsText.text = "Won: " + PlayerPrefs.GetInt(storingWin); ;
    }
    

    public void CloseGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
