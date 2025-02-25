using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameMode", menuName = "SO/Game Mode")]
public class GameModeManagerSO : ScriptableObject
{
    public int _timePreparation; 
    public int _timePlanification;
    public int _multiplicatorOfSoldiers;
    public int _nbLinesPlayer;
    public int _hpPlayer;
    public int _numberOfStepsBeforeIncreaseDamageTaken;
    public int _increaseDamageTaken;
    public int _nbSlotPlayer;
    public int _nbSlotHandMin;
    public int _nbSlotHandMax;
    public int _nbSlotShop;
    public int _addSlotShopPrice;
    public int _startingGold;
    public int _gainGoldIfWin;
    public int _gainGoldIfLose;
    public List<CardSO> _cardsAvailable;
}
