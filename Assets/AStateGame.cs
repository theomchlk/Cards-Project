using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class AStateGame : MonoBehaviour
{
    
    public int time;
    public TimerManager timerManager;
    public Shop[] shops;
    public abstract bool needCanvas { get; set; }
    
    //transition
    public CanvasGroup canvasGroupTransition;
    [HideInInspector] public TextMeshProUGUI transitionText;
    public bool inTransition = true;
    private bool transitionGrow = true;
    public float transitionTime = 3;
    
    
    public abstract void SetStateGame();

    public void Transition()
    {
        if (inTransition)
        {
            if (transitionGrow)
            {
                if (canvasGroupTransition.alpha < 1)
                {
                    canvasGroupTransition.alpha += Time.deltaTime;
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
            else if (canvasGroupTransition.alpha > 0)
            {
                canvasGroupTransition.alpha -= Time.deltaTime;
            }
            else
            {
                inTransition = false;
                transitionGrow = true;
                transitionTime = 3;
            }
        }
    }
    
}
