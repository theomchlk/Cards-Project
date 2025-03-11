using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
public class BoardDisplayer : MonoBehaviour
{
    public int nbLines;
    public int nbSlots;
    [SerializeField] private GameObject line;
    public GameObject slot;
    public Player[] players;
    public MapManager mapManager;


    public void Start()
    {
        UpdateBoard();
    }
    

    private int lastNbLines = 0;

    private int lastNbSlots = 0;


    [ContextMenu("UpdateBoard")]
    public void UpdateBoard()
    {
        mapManager.SetSpawnLocation(); //Create the same number of spawn location on each player field than the number of slot 
        foreach (Player player in players)
        {
            //UpdateLines(player);
            ClearLines(player);
            UpdateSlots(player);
        }
    }
    
    /* V1
    private void UpdateLines(Player player){
        ClearLines(player);
        for (int i = 0; i < nbLines ; i++){
            GameObject newLine = Instantiate(line, player.transform);
            newLine.name = "Line_" + (i + 1);

            LineController lineController = newLine.GetComponent<LineController>();
            if (lineController != null){
                lineController.ClearSlots();
                lineController.AddSlots(nbSlots);
                lastNbSlots++;
            }

        }
        lastNbLines = nbLines;
    }


    private void UpdateSlots(Player player){
        for (int i = 0 ; i < nbLines ; i++){
            LineController lineController = player.transform.GetChild(i).GetComponent<LineController>();
            if (lineController != null){
                lineController.ClearSlots();
                lineController.AddSlots(nbSlots);
            }
        }
    }
    */
    
    private void ClearLines(Player player){
        for (int i = player.transform.childCount - 1 ; i >= 0 ; i--){
            DestroyImmediate(player.transform.GetChild(i).gameObject);
        }
    }

    private void UpdateSlots(Player player)
    {
        for (int i = 0; i < nbLines; i++)
        {
            GameObject newLineController = Instantiate(line, player.transform);
            newLineController.name = "Line_" + (i + 1);
            for (int j = 0; j < nbSlots; j++)
            {
                GameObject newSlot = Instantiate(slot, newLineController.transform);
                newSlot.name = "Slot_" + (j + 1);
                if (newSlot.GetComponent<SlotForPlayer>() != null)
                {
                    newSlot.GetComponent<SlotForPlayer>().position = new Tuple<int, int>(i, j);
                }
                Debug.Log(newSlot.GetComponent<SlotForPlayer>().position);
            }
        }
    }
    
    

}
