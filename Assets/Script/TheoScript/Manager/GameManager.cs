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
    public int numberOfStepsBeforeIncreaseDamageTaken;
    public int increaseDamageTaken;
    public int multiplicatorOfSoldiers;
    
    //field for the game

    public int playerStillAlive;

    public int nbOfPlayersReady = 0;
    public AStateGame[] statesGame;
    public int stateStep = 0;
    public bool stateWasSet = false;
    private List<ReadyButton> readyButtons = new List<ReadyButton>();
    
    public void Awake()
    {
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

        foreach (AStateGame stateGame in statesGame)
        {
            stateGame.timerManager = timerManager;
        }
    }
    

    public void Start()
    {
        statesGame[stateStep].SetStateGame();
    }

    public void Update()
    {
        /* Doit etre supprimer quand il y aura deux joueurs
        if (playerStillAlive > 1)
        {
            if (stateWasSet < statesGame.Length)
            MakeStateGame();
        }
        */
        if (stateStep >= statesGame.Length)
        {
            stateStep = 0;
            nbRounds++;
            foreach (Player player in players)
            {
                player.shop.Addgold(player.shop.gainGoldIfWin);
            }
        }
        MakeStateGame();
    }

    public void MakeStateGame()
    {
        if (statesGame[stateStep].needCanvas)
        {
            if (!stateWasSet)
            {
                statesGame[stateStep].SetStateGame();
                ResetReadyButton();
                nbOfPlayersReady = 0;
                if (statesGame[stateStep].inTransition)
                {
                    statesGame[stateStep].Transition();
                }
                else
                {
                    statesGame[stateStep].inTransition = true;
                    stateWasSet = true;
                }
                
            }

            if (nbOfPlayersReady == players.Length)
            {
                timerManager.timeRemaining = 0;
            }
        }
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
