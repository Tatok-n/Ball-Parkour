using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarphicsTier : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void ChangeGraphics(int val)
    {
        QualitySettings.SetQualityLevel(val, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
