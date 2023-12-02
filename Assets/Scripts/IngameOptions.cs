using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameOptions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Options;
    public TimeRate tc;
    public MouseController mc;
    public GameObject baseUI;
    // Start is called before the first frame update

    public void OptionsExit()
    {
        Options.SetActive(false);
        baseUI.SetActive(true);
        tc.timescale = 1;
        mc.locked = true;
        mc.vis = false;

    }

    public void Quit()
    {
        Application.Quit();
    }
}
