using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Player : AContainsSlots
{


    public PlayerSO playerSO;
    public bool ready = false;
    public AShop shop;
    public GameObject playerField;
    /*[HideInInspector]*/ public Dictionary<Tuple<int ,int>, CardLogic> slotWithCard = new Dictionary<Tuple<int ,int>, CardLogic>();


    private int playerHp;
    private bool isDead;
    [HideInInspector] public bool haveWin = false;

    public Image image;


    public void Awake()
    {
        isDead = false;
        playerHp = playerSO._hp;
        


    }


    public void Losehp()
    {
        playerHp -= playerSO._damageTaken;
    }

    public void SetReadyPreparation()
    {
        ready = !ready;
    }

    public void GainInEndRound()
    {
        if (haveWin)
        {
            shop.GainIfWin();
        }
        else
        {
            shop.GainIfLose();
        }
    }

    public void SetPlayerField()
    {
        int nbSlots = transform.GetChild(0).childCount;
        foreach (Tuple<int, int> position in slotWithCard.Keys)
        {
            Debug.Log(playerField);
            
            Debug.Log(slotWithCard[position].cardSO._troup);
            foreach (Tuple<int, int> position1 in slotWithCard.Keys)
            {
                Debug.Log(position1);
                Debug.Log(slotWithCard[position1]);
                Debug.Log(slotWithCard[position1].cardSO._troup);

            }
            int spawnerInHierarchie = nbSlots * position.Item1 + position.Item2;
            Debug.Log(playerField);
            GameObject newTroups = Instantiate(slotWithCard[position].cardSO._troup, playerField.transform.GetChild(spawnerInHierarchie));
            newTroups.transform.localPosition = Vector3.zero;
            newTroups.name = slotWithCard[position].cardName;
        }
    }

    /* V1 (V2 fonctionne avec slotWithCard)
    public void SetPlayerField()
    {
        int indexForField = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform line = transform.GetChild(i);
            for (int j = 0; j < line.transform.childCount; j++)
            {
                Transform slot = line.transform.GetChild(j);
                if (slot.childCount > 0)
                {
                    ;
                    playerField.transform.GetChild(indexForField);
                }

                indexForField++;
            }
        }
    }
    */

    public void ClearField()
    {
        for (int i = 0; i < playerField.transform.childCount; i++)
        {
            Destroy(playerField.transform.GetChild(i).gameObject);
        }
    }
}



