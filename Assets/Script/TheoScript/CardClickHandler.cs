using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardClickHandler : MonoBehaviour, IPointerClickHandler
{
    
    
    public static int nbCardInUse = 0; 
    
    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.pointerClick.transform.parent.parent.parent.GetComponent<Player>() != null)
        {
            Debug.Log("oui");
        }
    }
    
    
}
