using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public bool[] levelStatus;
    public bool ChangeNeeded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ChangeNeeded)
        {
            if (levelStatus[0])
            {
                SceneManager.LoadScene("Testing scene", LoadSceneMode.Single);
            } else if (levelStatus[1])
            {
                SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
            }
        }
        ChangeNeeded = false;
    }
}
