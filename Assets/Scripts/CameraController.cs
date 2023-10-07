using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public Transform Target;
    public InputAction mousemvmt;
    public Transform Mover;
    public Collider Orbit;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = (Target.position + offset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        mousemvmt.Enable();
    }

    void OnDisable()
    {
        mousemvmt.Disable();
    }



    void FixedUpdate()
    {
        Vector2 LookVal = mousemvmt.ReadValue<Vector2>();
        Vector3 newPos = new Vector3(LookVal.x, LookVal.y, 0f);
        Mover.position += newPos;
        //Gizmos.DrawSphere(Orbit.ClosestPoint(Mover.position), 0.1f);
        Mover.position = Orbit.ClosestPoint(Mover.position);
        transform.position = Mover.position;
    }
}
