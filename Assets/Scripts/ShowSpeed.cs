using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSpeed : MonoBehaviour
{
    public Movement mov;
    public float ActualSpeed = 0f;
    public Text ValueText;

    // Start is called before the first frame update
    void Start()
    {
           
    
    }

    // Update is called once per frame
    void Update()
    {
        ActualSpeed = mov.CurrSpeed; 
        ValueText.text = ActualSpeed.ToString();
    }
}
