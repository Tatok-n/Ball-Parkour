using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MouseController : MonoBehaviour
{
    public bool vis;
    public bool locked;
    public CinemachineFreeLook brain;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        vis = false;
        locked = true;
    }

    

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = vis;
        if (!locked)
        {
            Cursor.lockState = CursorLockMode.None;
        } else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ChangeSens(float val)
    {
        brain.m_YAxis.m_MaxSpeed = 15*val;
        brain.m_XAxis.m_MaxSpeed = 450 * val;
    }
}
