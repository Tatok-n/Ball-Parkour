using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BANANA_ROTATE : MonoBehaviour
{
    public Transform pivot;
    public float speed;
    public Vector3 newrot;
    public Vector3 xyz;
    // Start is called before the first frame update
    void Start()
    {
        newrot = pivot.eulerAngles; 
    }

    // Update is called once per frame
    void Update()
    {
        newrot += speed*xyz;
        pivot.eulerAngles = newrot;
    }
}
