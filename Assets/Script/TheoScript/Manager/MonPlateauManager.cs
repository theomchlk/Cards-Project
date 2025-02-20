using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class MonPlateauController : MonoBehaviour
{

    [SerializeField] private int nbLines;

    [SerializeField] private int nbSlots;

    [SerializeField] private GameObject line;

    private int lastNbLines = 0;

    private int lastNbSlots = 0;


    [ContextMenu("UpdateGrid")]
    void UpdateGrid(){
        if (!Application.isPlaying && lastNbLines != nbLines){
            UpdateLines();
        }
        if (!Application.isPlaying && lastNbSlots != nbSlots){
            UpdateSlots();
            lastNbSlots = nbSlots;
        }
    }

//    [ContextMenu ("UpdateLines")]
    void UpdateLines(){
        ClearLines();
        for (int i = 0; i < nbLines ; i++){
            GameObject newLine = Instantiate(line, transform);
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

    void UpdateSlots(){
        for (int i = 0 ; i < nbLines ; i++){
            LineController lineController = transform.GetChild(i).GetComponent<LineController>();
            if (lineController != null){
                lineController.ClearSlots();
                lineController.AddSlots(nbSlots);
            }
        }
    }

    void ClearLines(){
        Debug.Log(transform.childCount);
        for (int i = transform.childCount - 1 ; i >= 0 ; i--){
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

}
