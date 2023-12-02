using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRate : MonoBehaviour
{
    public float timescale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != timescale)
        {
            Time.timeScale = timescale;
        }
    }
}
