using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;



public class CardLogic : MonoBehaviour
{
    public CardSO cardSO;
    public String cardName;
    public String cardDescription;
    public int value;
    public int percentageLessWhenRefund;
    private int nbSoldiers;
    private int health; 
    private int range;
    private int damage;
    private int speed;

    public void Awake()
    {
        cardName = cardSO._cardName;
        cardDescription = cardSO._cardDescription;
        value = cardSO._value;
        percentageLessWhenRefund = cardSO._percentageLessWhenRefund;
        nbSoldiers = cardSO._nbSoldiers;
        health = cardSO._health;
        range = cardSO._range;
        damage = cardSO._damage;
        speed = cardSO._speed;

    }
}
