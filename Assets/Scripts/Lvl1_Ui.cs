using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Lvl1_Ui : MonoBehaviour

{
    public TextMeshProUGUI IntroText;
    public Collider FirstIteration;
    public bool passedIntro;
    private float timer;
    public GameObject infobois;
    // Start is called before the first frame update
    void Start()
    {
        infobois.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer> 5)
        {
            passedIntro = true;
        }

        if (passedIntro)
        {
            IntroText.enabled = false;
            infobois.SetActive(true);

        }
    }
}
