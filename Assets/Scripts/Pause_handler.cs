using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_handler : MonoBehaviour
{
    public MouseController mc;
    public TimeRate tc;
    public GameObject player;
    public GameObject menu;
    public GameObject baseUI;
    public IngameOptions op;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnPause()
    {
        if (tc.timescale ==0)
        {
            op.OptionsExit();
            return;
        }
        tc.timescale = 0;
        menu.SetActive(true);
        mc.locked = false;
        mc.vis = true;
        baseUI.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
