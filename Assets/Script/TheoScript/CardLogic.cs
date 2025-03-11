using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;



public class CardLogic : MonoBehaviour
{
    public CardSO cardSO;
    public GameObject soldier;
    public String cardName;
    public String cardDescription;
    public int value;
    public int percentageLessWhenRefund;
    private int nbSoldiers;
    private int health; 
    private int range;
    private int damage;
    private int speed;

    public CanvasGroup canvasGroup;

    public CardDragHandler dragTechnology;
    public CardClickHandler clickTechnology;

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

    /* Si je m'embete à instantier les troupes avec coordonnées
    public void InstantiateTroups(int x, int y)
    {
        List<GameObject> listOfSoldier = new List<GameObject>();
        for (int i = 0; i < nbSoldiers; i++)
        {
            Instantiate(soldier, new Vector3(x, y, 0), Quaternion.identity);
            listOfSoldier.Add(soldier);
        }
        return listOfSoldier;
    }
    */
    
}
