using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanificationManager : AStateGame
{

    private List<CanvasGroup> canvasGroups = new List<CanvasGroup>();
    public override bool needCanvas { get; set; } = true;

    public void Awake()
    {
        Debug.Log("Planification Manager");
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
                shop.textForShop.gameObject.SetActive(true);
                shop.textForShop.text = "EN GUERRE";
            }
            
            canvasGroup.alpha = 0.5f;
            canvasGroup.blocksRaycasts = false;
        }
    }
}
