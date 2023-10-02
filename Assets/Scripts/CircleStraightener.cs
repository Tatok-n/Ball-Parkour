using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleStraightener : MonoBehaviour
{
    public Transform ground;
    public GameObject parent;
    private Movement parentScript;
    public Transform orientation;

    void Start() {
        parentScript = parent.GetComponent<Movement>();
    }

    void Update()
    {
        ground = parentScript.ground;
        Vector3 orientation = ground.eulerAngles;
        orientation.x +=90;
        gameObject.GetComponent<Transform>().eulerAngles = orientation;
    }
}
