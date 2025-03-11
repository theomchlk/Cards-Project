using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public Board[] boards;
    public Player[] players;
    public Shop[] shops;
    public Other[] others;
    public PlayerSO playerSO;
    public GameObject[] playerReadyButtons;
    public GameManagerSO gameManagerSO;
    public TimerManager timerManager;
    public int nbRounds;
    public int numberOfStepsBeforeIncreaseDamageTaken;
    public int increaseDamageTaken;
    public int multiplicatorOfSoldiers;
    
    public int[,] fightRound = { {1, 0, 3, 2 }, { 2, 3, 0, 1 }, { 3, 2, 1, 0 } };
    public int[] actualFightRound = { -1, -1, -1, -1 };
    private int indexFightRound = 0;
    
    //field for the game

    public int playerStillAlive;

    public int nbOfPlayersReady = 0;
    public AStateGame[] statesGame;
    public int stateStep = 0;
    public bool stateWasSet = false;
    private List<ReadyButton> readyButtons = new List<ReadyButton>();
    
    public void Awake()
    {
        GameManager.instance = this;
        numberOfStepsBeforeIncreaseDamageTaken = gameManagerSO._numberOfStepsBeforeIncreaseDamageTaken;
        increaseDamageTaken = gameManagerSO._increaseDamageTaken;
        multiplicatorOfSoldiers = gameManagerSO._multiplicatorOfSoldiers;

        players = new Player[boards.Length];
        shops = new Shop[boards.Length];
        others = new Other[boards.Length];

        int j = 0;
        foreach (Board board in boards)
        {
            
            for (int i = 0; i < board.transform.childCount; i++)
            {

                if (board.transform.GetChild(i).GetComponent<Player>() != null)
                {

                    players[j] = board.transform.GetChild(i).GetComponent<Player>();
                }
                if (board.transform.GetChild(i).GetComponent<Shop>() != null)
                {

                    shops[j] = board.transform.GetChild(i).GetComponent<Shop>();
                }
                if (board.transform.GetChild(i).GetComponent<Other>() != null)
                {
                    
                    others[j] = board.transform.GetChild(i).GetComponent<Other>();
                }
            }

            j++;
        }
    
        Debug.Log(players.Length); 
        Debug.Log(shops.Length); 
        Debug.Log(others.Length);
        

        //Set buttons
        foreach (GameObject playerReadyButton in playerReadyButtons)
        {
            ReadyButton readyButton = playerReadyButton.transform.GetChild(1).GetComponent<ReadyButton>();
            Debug.Log(readyButtons);
            readyButtons.Add(readyButton);
            
        }

        foreach (AStateGame stateGame in statesGame)
        {
            stateGame.timerManager = timerManager;
        }
        
        SetActualFightRound();
    }
        

    public void SetOtherInStartRound()  //A revoir si il n'y a plus de 2/3 joueurs
    {
        SetImageOther();
        SetWidgetTextOther();
        ClearLinesOther();
        SetLinesOther();
        
    }

    public void SetWidgetTextOther() //A revoir si il n'y a plus de 2/3 joueurs
    {
        for (int i = 0; i < others.Length; i++)
        {
            others[i].textOther.text = "P" + (fightRound[indexFightRound, i] + 1);
        }

    }

    public void SetImageOther()
    {
        for (int i = 0; i < others.Length; i++)
        {
            others[i].image.color = players[fightRound[indexFightRound, i]].image.color;
        }
    }


    private void SetLinesOther()
    {
        for (int i = 0; i < players.Length; i++)
        {
            for (int j = 0; j < players[fightRound[indexFightRound, i]].transform.childCount; j++)
            {
                GameObject newObj = Instantiate(players[fightRound[indexFightRound, i]].transform.GetChild(j).gameObject, others[i].transform); 
                newObj.name = "Line " + j;
            }  
        }
    }

    private void ClearLinesOther()
    {
        foreach (Other other in others)
        {
            for (int i = 0; i < other.transform.childCount; i++)
            {
                Destroy(other.transform.GetChild(i).gameObject);
            }
        }
    }

    private void SetActualFightRound()
    {
        for (int i = 0; i < actualFightRound.Length; i++)
        {
            actualFightRound[i] = fightRound[indexFightRound, i];
        }
    }
    
    
    public void Update()
    {
        /* Doit etre supprimer quand il y aura deux joueurs
        if (playerStillAlive > 1)
        {
            if (stateStep < statesGame.Length)
            MakeStateGame();
        }
        */
        if (stateStep >= statesGame.Length)
        {
            indexFightRound++;
            if (indexFightRound >= fightRound.Length)
            {
                indexFightRound = 0;
            }

            SetActualFightRound();
            stateStep = 0;
            nbRounds++;
            foreach (Player player in players)
            {
                player.GainInEndRound();
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
                if (stateStep == 0)
                {
                    SetOtherInStartRound();
                }
                statesGame[stateStep].SetStateGame();
                ResetReadyButton();
                nbOfPlayersReady = 0;
                Debug.Log(statesGame[stateStep].inTransition);
                if (statesGame[stateStep].inTransition)
                {
                    statesGame[stateStep].Transitions();
                }
                else // Pour les prochaines transitions
                {
                    statesGame[stateStep].inTransition = true;
                    stateWasSet = true;
                }
                
            }

            if (nbOfPlayersReady == playerReadyButtons.Length)
            {
                timerManager.timeRemaining = 0;
            }
        }
        else
        {
            
            if (!stateWasSet)
            {
                statesGame[stateStep].SetStateGame();
            }
            if (statesGame[stateStep].inTransition)
            {
                statesGame[stateStep].Transitions();
            }
        }
    }
    

    public void ResetReadyButton()
    {
        foreach (ReadyButton readyButton in readyButtons)
        {
            readyButton.ResetButton();
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

    
    
    
    
    
    
    
    
    
    
    
    
    
    

    
    


}
