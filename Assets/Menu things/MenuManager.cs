using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string startlvl;
    public GameObject Options;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Start_Level()
    {
        SceneManager.LoadScene(startlvl);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void OptionsMenu()
    {
        Options.SetActive(true);
    }

    public void OptionsExit()
    {
        Options.SetActive(false);
    }
    
}
