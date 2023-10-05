using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Revamped_Movement : MonoBehaviour
{
    public  Rigidbody rb;
    public float Speed;
    public float movementX;
    public float movementY;
    public Transform orientation;
    public int boostsY;
    public int boostsX;
    public int timerX = 60;
    public bool BoostY;
    public bool BoostX;

    // Start is called before the first frame update
    void Start()
    {
        BoostX = true;
        BoostY = true;
    }

    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        if (movementX==0)
        {
            BoostX = true;
        } else {
            BoostX = false;
        }
        movementY = movementVector.y;
        if (movementY == 0)
        {
            BoostY = true;
        }
        else
        {
            BoostY = false;
        }



    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        Vector3 Forward = orientation.right; //right is forward for some reason, change later on 
        Vector3 Right = orientation.forward;
        Forward.y = 0f;
        Right.y = 0f;
        if (!BoostX & boostsX >1) //|| !BoostY
        {
            Speed = 150;
            boostsX -= 1;
        } else
        {
            Speed = 5;
        }
        
        Vector3 movement = movementX*Forward+movementY*Right;
        rb.AddForce(movement*Speed);
    }
}
