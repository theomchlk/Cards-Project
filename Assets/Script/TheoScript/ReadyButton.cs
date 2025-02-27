using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyButton : MonoBehaviour
{
    public GameManager gameManager;
    public bool ready = false;
    private Image buttonImage;
    public Color colorDefault = Color.white;
    public Color colorPressed = Color.grey;

    public void Awake()
    {
        buttonImage = GetComponent<Image>();
    }
    
    public void SetReady()
    {
        Debug.Log(gameManager);
        if (!ready)
        {
            ready = true;
            buttonImage.color = colorDefault;
            gameManager.nbOfPlayersReady++;
            
        }
        else
        {
            ready = false;
            buttonImage.color = colorPressed;
            gameManager.nbOfPlayersReady--;
        }
    }

    public void ResetButton()
    {
        ready = false;
    }
}
