using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class AContainsSlots : MonoBehaviour
{
    [SerializeField] private Transform[] _cardCanComesFrom; 
    public Transform[] cardCanComesFrom => _cardCanComesFrom;
    

    public bool ContainsSlot(Transform container)
    {
        return _cardCanComesFrom.Contains(container);
    }
}
