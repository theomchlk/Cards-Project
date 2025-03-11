using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardSO", menuName = "Card/CardSO")]
public class CardSO : ScriptableObject
{
    public GameObject _troup;
    public String _cardName;
    public String _cardDescription;
    public int _value;
    public int _percentageLessWhenRefund = 70;
    public int _nbSoldiers;
    public int _health;
    public int _range;
    public int _damage;
    public int _speed;
    
}
