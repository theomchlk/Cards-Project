using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;



public class CardLogic : MonoBehaviour
{
    public CardSO cardSO;
    private String cardName;
    private int value;
    private int nbSoldiers;

    public void Awake()
    {
        cardName = cardSO._cardName;
        value = cardSO._value;
        nbSoldiers = cardSO._nbSoldiers;

    }
}
