using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateTransition : MonoBehaviour
{
    public TextMeshProUGUI transitionText;
    public CanvasGroup canvasGroupTransition;
    
    public bool inTransition = true;
    private bool transitionGrow = true;
    public float transitionTime = 3;
    

    
}
