using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameMode", menuName = "SO/Game Mode")]
public class GameManagerSO : ScriptableObject
{
    public int _timePreparation; 
    public int _timePlanification;
    public int _numberOfStepsBeforeIncreaseDamageTaken;
    public int _increaseDamageTaken;
    public int _multiplicatorOfSoldiers;
}
