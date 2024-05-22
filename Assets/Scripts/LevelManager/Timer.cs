using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timerTime;
    private float timer;

    public Text textTimer;

    private void Start()
    {
        timer = timerTime;
    }
    private void Update()
    {
        timer -= Time.deltaTime;

        textTimer.text = timer.ToString("f0");
    }

    public bool TimerFinished() 
    {
        return timer <= 0;
    }
}
