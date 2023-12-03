using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelReset : MonoBehaviour
{
    public string level;
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
        
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

    void OnTriggerEnter()
    {

        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }
}
