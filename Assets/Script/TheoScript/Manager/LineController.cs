using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField] private GameObject slotForHand;

    public void AddSlots(int nbSlots){
        for (int i = 0 ; i < nbSlots ; i++)
        {
            GameObject newSlot = Instantiate(slotForHand, transform);
            newSlot.name = "Slot_" + (i + 1);
        }
    }

    public void ClearSlots(){
        for (int i = transform.childCount - 1 ; i >= 0 ; i--){
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

    

}
