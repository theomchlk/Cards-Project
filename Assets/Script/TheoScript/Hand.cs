using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hand : AContainsSlots
{
    private int nbSlotsAvailable ;

    [HideInInspector] public int minNbSlotsAvailable;
    [HideInInspector] public int maxNbSlotsAvailable;
    [HideInInspector] public GameObject slotForHand;
    

    
    public void Awake()
    {
        nbSlotsAvailable = transform.childCount;
    }


    public void ResetHand()
    {
        ClearHand();
        for (int i = 0; i < minNbSlotsAvailable; i++)
        {
            GameObject newSlot = Instantiate(slotForHand, transform);
            newSlot.name = "Slot_" + i + 1;
        }
        nbSlotsAvailable = minNbSlotsAvailable;
        
    }
    
    private void ClearHand()                                                  
    {                                                                         
        for (int i = transform.childCount - 1; i >= 0; i--)                   
        {                                                                     
            DestroyImmediate(transform.GetChild(i).gameObject);               
        }                                                                     
    }     
    
    public void AddSlot()
    {
        if (nbSlotsAvailable < maxNbSlotsAvailable)
        {
            GameObject newSlot = Instantiate(slotForHand, transform);
            nbSlotsAvailable++;
            newSlot.name = "Slot_" + nbSlotsAvailable;
        }
    }


    
}
