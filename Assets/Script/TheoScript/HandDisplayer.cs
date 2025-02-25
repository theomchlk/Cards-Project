using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDisplayer : MonoBehaviour
{
    private int minNbSlotsAvailable = 4;
    private int maxNbSlotsAvailable = 8;
    [SerializeField] private GameObject slotForHand;
    public List<Hand> hands;

    
    
    [ContextMenu("Reset Hand")]
    public void ResetHands()
    {
        foreach (Hand hand in hands)
        {
            hand.minNbSlotsAvailable = minNbSlotsAvailable;
            hand.maxNbSlotsAvailable = maxNbSlotsAvailable;
            hand.slotForHand = slotForHand;
            hand.ResetHand();
        }
    }
}
