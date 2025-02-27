using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public Player[] players;
    public PlayerSO playerSO;
    public GameObject[] playerReadyButtons;
    public GameManagerSO gameManagerSO;
    public TimerManager timerManager;
    public int nbRounds;
    public float timePreparation;
    public float timePlanification;
    public int numberOfStepsBeforeIncreaseDamageTaken;
    public int increaseDamageTaken;
    public int multiplicatorOfSoldiers;
    
    //field for the game

    public int nbOfPlayersReady = 0;
    public enum GameState { Preparation, Planification, War }
    public GameState currentState = GameState.Preparation;
    public bool stateWasSet = false;
    private List<ReadyButton> readyButtons = new List<ReadyButton>();
    
    public void Awake()
    {
        timePreparation = gameManagerSO._timePreparation;
        timePlanification = gameManagerSO._timePlanification;
        numberOfStepsBeforeIncreaseDamageTaken = gameManagerSO._numberOfStepsBeforeIncreaseDamageTaken;
        increaseDamageTaken = gameManagerSO._increaseDamageTaken;
        multiplicatorOfSoldiers = gameManagerSO._multiplicatorOfSoldiers;
        

        //Set buttons
        foreach (GameObject playerReadyButton in playerReadyButtons)
        {
            ReadyButton readyButton = playerReadyButton.transform.GetChild(1).GetComponent<ReadyButton>();
            Debug.Log(readyButtons);
            readyButton.gameManager = this;
            readyButtons.Add(readyButton);
            
        }
        

        
        
    }

    public void Start()
    {

    }

    public void Update()
    {
        if (currentState == GameState.Preparation)
        {
            Preparation();
            Debug.Log("Prep");
        }

        if (currentState == GameState.Planification)
        {
            Planification();
        }

        if (currentState == GameState.War)
        {
            Debug.Log("WAAAAR !");
        }
    }

    public void Preparation()
    {
        if (!stateWasSet)
        {
            SetPreparation();
            stateWasSet = true;
        }

        if (timerManager.timeRemaining < 0 || nbOfPlayersReady == players.Length)
        {
            currentState = GameState.Planification;
            stateWasSet = false;
        }
    }
    
    public void Planification()
    {
        if (!stateWasSet)
        {
            SetPlanification();
            stateWasSet = true;
        }

        if (timerManager.timeRemaining < 0 || nbOfPlayersReady == players.Length)
        {
            currentState = GameState.War;
            stateWasSet = false;
        }
    }

    public void SetPreparation()
    {
        timerManager.timeRemaining = timePreparation;
        ResetReadyButton();
        nbOfPlayersReady = 0;
    }
    
    public void SetPlanification()
    {
        timerManager.timeRemaining = timePlanification;
        ResetReadyButton();
        nbOfPlayersReady = 0;
    }

    public void ResetReadyButton()
    {
        foreach (ReadyButton readyButton in readyButtons)
        {
            readyButton.ready = false;
        }
    }
    
    public void IncreasingDamageTaken()
    {
        playerSO._damageTaken += increaseDamageTaken;
    }

    public void SetReady()
    {
        Debug.Log(nbOfPlayersReady);
    }
    
    //boucle de jeu 

    public void Round()
    {
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    

    
    


}
