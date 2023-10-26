using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Ender : MonoBehaviour
{
    public LevelManager lvl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter()
    {
        lvl.levelStatus[0] = true;
        lvl.ChangeNeeded = true;
    }
}
