using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    float counter = 60f;
    public TextMeshProUGUI countdown;
    GameManagerX gameManager;
    public bool timerCounting;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        countdown = gameObject.GetComponent<TextMeshProUGUI>();
    }


    public void Update()
    {

        if (counter > 0 && gameManager.isGameActive)
        {
            counter -= Time.deltaTime;
            countdown.text = "Time Left: " + Mathf.Round(counter);
            timerCounting = true;
        }
        else if (counter <= 0 && gameManager.isGameActive)
        {
            Debug.Log("The counter has stopped.");
            gameManager.GameOver();
            timerCounting = false;
        }

    }
}
