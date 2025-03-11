using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyButton : MonoBehaviour
{
    public bool ready = false;
    public Image buttonImage;
    public Color colorDefault = Color.white;
    public Color colorPressed = Color.grey;
    
    
    public void SetReady()
    {
        if (!ready)
        {
            IsReady();
        }
        else
        {   
            IsNotReady();
        }
    }

    public void IsReady()
    {
        ready = true;
        buttonImage.color = colorPressed;
        GameManager.instance.nbOfPlayersReady++;
    }

    public void IsNotReady()
    {
        ready = false;
        buttonImage.color = colorDefault;
        GameManager.instance.nbOfPlayersReady--;
    }

    public void ResetButton()
    {
        ready = false;
        buttonImage.color = colorDefault;
    }
}
