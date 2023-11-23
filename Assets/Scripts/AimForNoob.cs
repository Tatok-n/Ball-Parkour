using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimForNoob : MonoBehaviour
{
    public GrapplingGun gunpoint;

    // Update is called once per frame
    void Update()
    {
        if (gunpoint.tag == "RotatorBoi" && gunpoint.IsGrappling())
        {
            gameObject.GetComponent<Transform>().parent = gunpoint.connectedobject.GetComponent<Transform>(); //makes the aimpoint a child of rotating objects
        } else {
            gameObject.GetComponent<Transform>().position = gunpoint.pointlocation; }
    }
}
