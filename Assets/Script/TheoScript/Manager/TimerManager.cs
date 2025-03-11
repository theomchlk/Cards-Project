using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{   
    public GameManager gameManager;
    public TextMeshProUGUI[] timerTextPlayers;

    private String timerText;
    public float timeRemaining;

    public void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeRemaining / 60);                  
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText = $"{minutes:00}:{seconds:00}";
            foreach (TextMeshProUGUI timeTextPlayer in timerTextPlayers)
            {
                timeTextPlayer.text = timerText;
            }
            
        }
        else if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            Debug.Log(gameManager.stateStep);
            gameManager.statesGame[gameManager.stateStep].OnEndState();
            gameManager.stateStep++;
            gameManager.stateWasSet = false;
        }
    }
}