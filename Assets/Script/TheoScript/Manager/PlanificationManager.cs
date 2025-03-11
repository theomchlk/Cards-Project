using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class PlanificationManager : AStateGame
{
    
    public override bool needCanvas { get; set; } = true;


    public override void SetStateGame()
    {
        SetTextsTransition();
        timerManager.timeRemaining = time;

        for (int i = 0; i < boards.Length; i++)
        {
            SetShop(i);
            SetOther(i);
            SetCard(i);
        }
        
    }

    public override void SetTextsTransition()
    {
        foreach (StateTransition transition in transitions)
        {
            transition.transitionText.text = "Planification";
        }
    }


    public void SetShop(int i)
    {
        shops[i].textForShop.gameObject.SetActive(true); 
        shops[i].textForShop.text = "EN GUERRE";
        shops[i].canvasGroup.alpha = 0.5f;
        shops[i].canvasGroup.blocksRaycasts = false;
    }

    public void SetOther(int i)
    {
        others[i].canvasGroup.alpha = 1;
        others[i].canvasGroup.blocksRaycasts = true;
        others[i].gameObject.SetActive(true);
        int actualFightAgainst = GameManager.instance.actualFightRound[i];
        Debug.Log(actualFightAgainst);
        Debug.Log(players[actualFightAgainst]);
        if (actualFightAgainst >= 0) //si le joueur n'est pas mort
        {
            foreach (Tuple<int,int> position in players[actualFightAgainst].slotWithCard.Keys )
            {
                CardLogic newCard = Instantiate(players[actualFightAgainst].slotWithCard[position],
                    others[i].transform.GetChild(position.Item1).GetChild(position.Item2));
                newCard.name = newCard.cardSO._cardName;
            }
        }
        
    }

    public void SetCard(int i)
    {
        foreach (CardLogic card in players[i].slotWithCard.Values)
        {
            card.dragTechnology.enabled = false;
            card.clickTechnology.enabled = true;
        }
    }

    public void UnSetCard(int i)
    {
        foreach (CardLogic card in players[i].slotWithCard.Values)
        {
            card.dragTechnology.enabled = true;
            card.clickTechnology.enabled = false;
        }
    }

    public override void OnEndState()
    {
        for (int i = 0; i < boards.Length; i++)
        {
            UnSetCard(i);
        }
    }
}


