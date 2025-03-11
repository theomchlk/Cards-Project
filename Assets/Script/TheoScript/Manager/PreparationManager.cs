using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreparationManager : AStateGame
{
    public override bool needCanvas { get; set; } = true;

    
    public override void SetStateGame()
    {
        SetTextsTransition();
        timerManager.timeRemaining = time;

        for (int i = 0; i < boards.Length; i++)
        {
            if (others.Length > 0)
            {
                SetOther(i); 
            }

            if (shops.Length > 0)
            {
                SetShop(i);
            }
            

        }
    }

    public override void SetTextsTransition()
    {
        foreach (StateTransition transition in transitions)
        {
            transition.transitionText.text = "Preparation";
        }
    }
    

    public void SetOther(int i)
    {
        others[i].gameObject.SetActive(false);
        others[i].MakeInactive();
    }

    public void SetShop(int i)
    {
        shops[i].textForShop.gameObject.SetActive(false);
        shops[i].gameObject.SetActive(true);
        shops[i].canvasGroup.alpha = 1;
        shops[i].canvasGroup.blocksRaycasts = true;
    }
    

    public override void OnEndState()
    {
        
    }
    
}
