using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarManager : AStateGame
{ 
    public GameObject[] hands;
    
    
    
    public override bool needCanvas { get; set; } = false;
    public override void SetStateGame()
    {
        SetTextsTransition();
        InstantiateSoldierOnMap();
        DesactiveBoards();
        DesactiveHands();
        
    }
    
    public override void SetTextsTransition()
    {
        foreach (StateTransition transition in transitions)
        {
            transition.transitionText.text = "Confrontation";
        }
    }

    public void BeginOfWar()
    {
        ClearMap();
        DesactiveBoards();
        DesactiveHands();
        //InstantiateSoldierOnMap();
    }

    

    public void EndOfWar()
    {
        ActiveBoards();
        ActiveHands();
    }
    
    public void InstantiateSoldierOnMap()
    {
        foreach (Player player in players)
        {
            player.SetPlayerField();
        }
    }

    public void ActiveBoards()
    {
        foreach (Board board in boards)
        {
            board.gameObject.SetActive(true);
        }
    }

    public void DesactiveBoards()
    {
        foreach (Board board in boards)
        {
            board.gameObject.SetActive(false);
        }
    }
    
    public void ActiveHands()
    {
        foreach (GameObject hand in hands)
        {
            hand.SetActive(true);
        }
    }

    public void DesactiveHands()
    {
        foreach (GameObject hand in hands)
        {
            hand.SetActive(false);
        }
    }

    public void ClearMap()
    {
        foreach (Player player in players)
        {
            player.ClearField();
        }
    }

    public override void OnEndState()
    {
        ActiveBoards();
        ActiveHands();
    }
    
    
    
}
