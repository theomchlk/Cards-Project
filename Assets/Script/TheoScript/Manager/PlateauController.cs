using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlateauController : MonoBehaviour
{

    [SerializeField] private int nbLines;

    [SerializeField] private int nbSlots;

    [SerializeField] private GameObject line;

    private int lastNbLines = -1;

    private int lastNbSlots = -1;

    void Update(){
        Debug.Log(nbSlots);
        if (!Application.isPlaying && lastNbLines != nbLines){
            UpdateLines();
            lastNbLines = nbLines;
        }
        if (!Application.isPlaying && lastNbSlots != nbSlots){
            UpdateSlots();
            lastNbSlots = nbSlots;
        }
    }

    void UpdateLines(){
        ClearLines();
        for (int i = 0; i < nbLines ; i++){
            GameObject newLine = Instantiate(line, transform);
            newLine.name = "Line_" + (i + 1);
            LineController lineController = newLine.GetComponent<LineController>();
            if (lineController != null){
                lineController.ClearSlots();
                lineController.AddSlots(nbSlots);
            }
        }
    }

    void UpdateSlots(){
        for (int i = 0 ; i < nbLines ; i++){
            LineController lineController = transform.GetChild(i).GetComponent<LineController>();
            lineController.ClearSlots();
        }
        UpdateLines();
    }

    void ClearLines(){
        Debug.Log(transform.childCount);
        for (int i = transform.childCount - 1 ; i >= 0 ; i--){
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

}
