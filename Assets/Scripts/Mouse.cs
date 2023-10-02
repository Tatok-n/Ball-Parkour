using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public bool control;
    // Start is called before the first frame update
    void Start()
    {
        control = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("g"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            control = true;
        }

        if (Input.GetKeyDown("f"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            control = true;
        }

    }
}
