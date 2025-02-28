using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreparationManager : AStateGame
{
    
    private List<CanvasGroup> canvasGroups = new List<CanvasGroup>();
    public override bool needCanvas { get; set; } = true;

    
    

    public void Awake()
    {
        transitionText = canvasGroupTransition.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        foreach (Shop shop in shops)
        {
            canvasGroups.Add(shop.GetComponent<CanvasGroup>());
        }
        
    }
    public override void SetStateGame()
    {
        transitionText.text = "Preparation";
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
