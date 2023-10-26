
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class UiController : MonoBehaviour
{
    public TextMeshProUGUI GravText;
    public Revamped_Movement rm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GravText.text = "Current Gravity : " + (-Physics.gravity.y).ToString();
        GravText.text += "\n Current Speed :" + (Math.Round(rm.Velocity,2)).ToString();
    }
}
