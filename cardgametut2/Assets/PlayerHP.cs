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

    public float waitTime = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = 20;
        currentHP = 20;
    }

    // Update is called once per frame
    void Update()
    {

        hpText.text = currentHP + "/" + maxHP;
    }
}
