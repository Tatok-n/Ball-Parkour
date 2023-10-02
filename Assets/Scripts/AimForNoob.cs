using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimForNoob : MonoBehaviour
{
    public GrapplingGun gunpoint;

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Transform>().position = gunpoint.pointlocation;
    }
}
