using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject[] inLeftPart;
    public GameObject[] inRightPart;

    public void ButtonForShop()
    {
        foreach (GameObject go in inRightPart)
        {
            if (go.GetComponent<AShop>() != null)
            {
                go.SetActive(true);
            }
            else
            {
                go.SetActive(false);
            }
        }
    }

    public void ButtonForOther()
    {
        foreach (GameObject go in inRightPart)
        {
            if (go.GetComponent<Other>() != null)
            {
                go.SetActive(true);
            }
            else
            {
                go.SetActive(false);
            }
        }
    }
}
