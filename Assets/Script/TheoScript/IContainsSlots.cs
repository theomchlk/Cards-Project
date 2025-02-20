using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IContainsSlots
{
    Transform transform { get; }
    Transform[] cardCanComesFrom { get;}

    public bool ContainsSlot(Transform slot);
}
