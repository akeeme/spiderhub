using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timerStart;
    public float timerDuration = 5;
    //public float smokeDuration = 5;
    // Start is called before the first frame update
    void Start()
    {
        timerStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerStart + timerDuration < Time.time)
        {
            Destroy(gameObject);
        }
    }
}
