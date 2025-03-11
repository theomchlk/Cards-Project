using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public BoardDisplayer boardDisplayer;
    public GameObject[] fields;
    public GameObject spawnLocation;

    [ContextMenu("Set Spawn Location")]
    public void SetSpawnLocation()
    {
        ClearSpawnLocation();
        CreateSpawnLocation();
    }
    
    [ContextMenu("Clear Spawn Location")]
    public void CreateSpawnLocation()
    {
        float x, startX, z, startZ;
        
        startX = -5 + 5f / boardDisplayer.nbLines;
        startZ = 5 - 5f / boardDisplayer.nbSlots;
        
        foreach (GameObject field in fields)
        {
            for (int i = 0; i < boardDisplayer.nbLines; i++)
            {
                x = startX + (10f / boardDisplayer.nbLines) * i;
                for (int j = 0; j < boardDisplayer.nbSlots; j++)
                {
                    z = startZ - (10f / boardDisplayer.nbSlots) * j;
                    Vector3 location = new Vector3(x, 0, z);
                    GameObject newSpawnLocation = Instantiate(spawnLocation, field.transform);
                    newSpawnLocation.transform.localPosition = location;
                    newSpawnLocation.name = "SpawnLocation " + i + j;
                }
            }
        }
    }

    [ContextMenu("Clear Spawn Location")]
    public void ClearSpawnLocation()
    {
        foreach (GameObject field in fields)
        {
            for (int i = field.transform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(field.transform.GetChild(i).gameObject);
            }
        }
    }
    

}
