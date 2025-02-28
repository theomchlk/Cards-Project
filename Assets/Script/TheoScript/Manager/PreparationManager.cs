using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparationManager : AStateGame
{
    
    private List<CanvasGroup> canvasGroups = new List<CanvasGroup>();
    public override bool needCanvas { get; set; } = true;

    


    public void Awake()
    {
        foreach (Shop shop in shops)
        {
            canvasGroups.Add(shop.GetComponent<CanvasGroup>());
        }
        
    }
    public override void SetStateGame()
    {
        timerManager.timeRemaining = time;
        foreach (CanvasGroup canvasGroup in canvasGroups)
        {
            foreach (Shop shop in shops)
            {
                shop.textForShop.gameObject.SetActive(false);

            }
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
        }
    }
}
