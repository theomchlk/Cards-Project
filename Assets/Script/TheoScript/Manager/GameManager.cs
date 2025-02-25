using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player[] players;
    public PlayerSO playerSO;
    public GameManagerSO gameManagerSO;
    public int nbRounds;
    public int timePreparation;
    public int timePlanification;
    public int numberOfStepsBeforeIncreaseDamageTaken;
    public int increaseDamageTaken;
    public int multiplicatorOfSoldiers;
    
    public void Awake()
    {
        timePreparation = gameManagerSO._timePreparation;
        timePlanification = gameManagerSO._timePlanification;
        numberOfStepsBeforeIncreaseDamageTaken = gameManagerSO._numberOfStepsBeforeIncreaseDamageTaken;
        increaseDamageTaken = gameManagerSO._increaseDamageTaken;
        multiplicatorOfSoldiers = gameManagerSO._multiplicatorOfSoldiers;
        

    }
    public void IncreasingDamageTaken()
    {
        playerSO._damageTaken += increaseDamageTaken;
    }
    
    //boucle de jeu
}
