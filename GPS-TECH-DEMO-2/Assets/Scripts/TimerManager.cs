using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static List<Timer> currentTimer = new List<Timer>();

    private void Update() { TickTimers(); }

    private void TickTimers()
    {
        foreach (Timer timer in currentTimer)
        {

        }
    }



}

public class Timer
{
    public event Action OnCycleComplete;
    public float currentTime { get; set; }
    public float resetTime { get; set; }
    public void ResetTime() { currentTime = 0; }

}
