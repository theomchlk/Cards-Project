using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AStateGame : MonoBehaviour
{
    public int time;
    public TimerManager timerManager;
    public Shop[] shops;
    public abstract bool needCanvas { get; set; }

    public abstract void SetStateGame();
    
    
}
