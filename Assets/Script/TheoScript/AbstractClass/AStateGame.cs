using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class AStateGame : MonoBehaviour
{
    
    public int time;
    public TimerManager timerManager;
    public abstract bool needCanvas { get; set; }
    
    //transition
    public StateTransition[] transitions;

    
    public bool inTransition = true;
    private bool transitionGrow = true;
    public float transitionTime = 3;
    
    
    public Board[] boards;
    public Player[] players;
    public Shop[] shops;
    public Other[] others;


    public void Start()
    {
        
        
        /*
        players = new Player[boards.Length];
        shops = new Shop[boards.Length];
        others = new Other[boards.Length];
        
        foreach (Board board in boards)
        {
            for (int i = 0; i < board.transform.childCount; i++)
            {
                if (board.transform.GetChild(i).GetComponent<Player>() != null)
                {
                    players[i] = board.transform.GetChild(i).GetComponent<Player>();
                }
                if (board.transform.GetChild(i).GetComponent<Shop>() != null)
                {
                    shops[i] = board.transform.GetChild(i).GetComponent<Shop>();
                }
                if (board.transform.GetChild(i).GetComponent<Other>() != null)
                {
                    others[i] = board.transform.GetChild(i).GetComponent<Other>();
                }
            }
            
        }
        */
        Debug.Log(GameManager.instance);
        boards = GameManager.instance.boards;
        players = GameManager.instance.players;
        shops = GameManager.instance.shops;
        others = GameManager.instance.others;
        Debug.Log(others.Length);
        
    }
    
    
    
    public abstract void SetStateGame();

    public abstract void SetTextsTransition();

    public void Transitions()
    {
        foreach (StateTransition transition in transitions)
        {
            Transition(transition);
        }
    } 
    
    public void Transition(StateTransition transition)
    {
        if (inTransition)
        {
            if (transitionGrow)
            {
                if (transition.canvasGroupTransition.alpha < 1)
                {
                    transition.canvasGroupTransition.alpha += Time.deltaTime;
                }
                else
                {
                    transitionGrow = false;
                }
            }
            else if (transitionTime > 0)
            {
                transitionTime -= Time.deltaTime;
            }
            else if (transition.canvasGroupTransition.alpha > 0)
            {
                transition.canvasGroupTransition.alpha -= Time.deltaTime;
            }
            else
            {
                Debug.Log("hello");
                inTransition = false;
                transitionGrow = true;
                transitionTime = 3;
            }
        }
    }

    public abstract void OnEndState();

}
