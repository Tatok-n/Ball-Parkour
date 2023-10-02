using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROTATE : MonoBehaviour
{
    public Transform parent;
    

    public void Update() {
        Vector3 CurrentAngles = parent.eulerAngles;
        Vector3 CurrentPos = parent.position;
        gameObject.GetComponent<Transform>().eulerAngles = CurrentAngles;
        gameObject.GetComponent<Transform>().position = CurrentPos;
    }
}
