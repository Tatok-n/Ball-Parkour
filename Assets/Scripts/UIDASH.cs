using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class UIDASH : MonoBehaviour
{
    public TextMeshProUGUI DashText;
    public Revamped_Movement rm;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DashText.text = "Front Back Boosts : " + rm.boostsY.ToString();
        DashText.text += "\n Left Right Boosts :" + rm.boostsX.ToString();
        DashText.text += "\n Bursts :" + rm.Bursts.ToString();
    }
}
