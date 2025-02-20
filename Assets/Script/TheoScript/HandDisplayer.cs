using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDisplayer : MonoBehaviour
{
    public List<Hand> hands;
    public int minNbSlotsAvailable = 5;
    public int maxNbSlotsAvailable = 8;
    public SlotForHand slotForHand;

    public void Start()
    {
        foreach (Hand hand in hands)
        {
            
        }
    }
    
    [ContextMenu("Reset Hand")]
    public void ResetHands()
    {
        foreach (Hand hand in hands)
        {
            ClearHand();
            for (int i = 0; i < minNbSlotsAvailable; i++)
            {
                SlotForHand newSlot = Instantiate(slotForHand, transform);
                newSlot.name = "Slot_" + i + 1;
            }
        }
    }

    private void ClearHand()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }
}
