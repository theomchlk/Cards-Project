using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Other : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public Image image; 
    public TextMeshProUGUI textOther;

    public void MakeActive()
    {
        gameObject.SetActive(true);
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
    }

    public void MakeInactive()
    {
        gameObject.SetActive(false);
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.7f;
        
    }
    
    
}
