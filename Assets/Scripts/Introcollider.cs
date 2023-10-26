using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introcollider : MonoBehaviour
{
    public Lvl1_Ui UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay()
    {
        UI.passedIntro = true;
        Debug.Log("A");
    }
}
