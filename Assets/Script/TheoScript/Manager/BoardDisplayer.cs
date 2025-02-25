using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
public class BoardDisplayer : MonoBehaviour
{
    [SerializeField] private int nbLines;
    [SerializeField] private int nbSlots;
    [SerializeField] private GameObject line;
    public List<GameObject> players;
    
    
    

    private int lastNbLines = 0;

    private int lastNbSlots = 0;


    [ContextMenu("UpdateBoard")]
    public void UpdateBoard()
    {
        foreach (GameObject player in players)
        {
            UpdateLines(player);
            UpdateSlots(player);
        }
    }
    
    private void UpdateLines(GameObject player){
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

    private void UpdateSlots(GameObject player){
        for (int i = 0 ; i < nbLines ; i++){
            LineController lineController = player.transform.GetChild(i).GetComponent<LineController>();
            if (lineController != null){
                lineController.ClearSlots();
                lineController.AddSlots(nbSlots);
            }
        }
    }

    private void ClearLines(GameObject player){
        Debug.Log(player.transform.childCount);
        for (int i = player.transform.childCount - 1 ; i >= 0 ; i--){
            DestroyImmediate(player.transform.GetChild(i).gameObject);
        }
    }
    
    

}
