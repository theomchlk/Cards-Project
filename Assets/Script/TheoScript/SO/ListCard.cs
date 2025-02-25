using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListCard", menuName = "SO/ListCard", order = 1)]
public class ListCard : ScriptableObject, IEnumerable<GameObject>
{
    public List<GameObject> listCard;
    public IEnumerator<GameObject> GetEnumerator()
    {
        return listCard.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
