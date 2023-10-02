using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDaBoi : MonoBehaviour
{
    public GrapplingGun grappling;
    public GameObject Grapple;
    



    void Update() {
        if (!grappling.IsGrappling()) {
            Grapple.GetComponent<SnapOntoItemBar>().enabled = true;
            return;
        } else {
        Grapple.GetComponent<SnapOntoItemBar>().enabled = false;
        }
        transform.LookAt(grappling.GetGrapplePoint());
        

        

    }

}
