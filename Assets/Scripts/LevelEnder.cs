using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnder : MonoBehaviour
{
    public LevelManager lvl;
    public int lvlchange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        lvl.levelStatus[lvlchange] = true;
        lvl.ChangeNeeded = true;
    }
}
