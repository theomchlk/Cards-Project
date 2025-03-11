using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotForArrow : MonoBehaviour, IDropHandler
{
    public Tuple<int, int> position;
    
    public void OnDrop(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
}
