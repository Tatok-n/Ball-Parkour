using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Revamped_Movement : MonoBehaviour
{
    public  Rigidbody rb;
    public float Speed;
    public float BoostValue;
    public float movementX;
    public float movementY;
    public Transform orientation;
    public int boostsY;
    public int boostsX;
    public int timerX = 60;
    public int timerY = 60;
    public bool BoostY;
    public bool BoostX;
    public float[] parametersX = new float[2];
    public float[] parametersY = new float[2];

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
        movementY = movementVector.y;
        /*if (movementX==0)
        {
            BoostX = true;
        } else {
            BoostX = false;
        }
        
        if (movementY == 0)
        {
            BoostY = true;
        }
        else
        {
            BoostY = false;
        }
        */
    }

    float[] ManageSpeed (float Direction1, float Direction2, bool Boost, int counter)
    {
        //if (counter==0)
        //{
        //return 0f;
        //}
        if (!Boost && Direction1!= 0)
        {
            return new[] { 0f, 0f };
            
            
        } else if (!Boost && Direction1==0)
        {
            return new[] { 0f, 1f };
        }
       
        else if ((Direction2==0) & (Boost) & (Direction1!= 0)) // is gonna start moving, needs boost
        {
            return new[] { Direction1*BoostValue, 0f };
        }
  
        return new[] { 0f, 2f };
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
        
        //float[] parametersX = new float[2];
        parametersX = ManageSpeed(movementX, movementY, BoostX, boostsX);
        if (parametersX[1] == 1)
        {
            BoostX = true;
        }
        else if (parametersX[1] == 0)
        {
            BoostX = false;
        }
       
        



        //float[] parametersY = new float[2];
        parametersY = ManageSpeed(movementY, movementX, BoostY, boostsY);
        
        
        if (parametersY[1] == 1)
        {
            BoostY = true;
        }
        else if (parametersY[1] == 0)
        {
            BoostY = false;
        }

        Debug.Log(parametersX[0]);
        Debug.Log(parametersY[0]);

        Vector3 movement = (movementX+parametersX[0])*Forward+ (movementY + parametersY[0]) * Right;
        Debug.DrawLine(rb.position, rb.position + movement);
        rb.AddForce(movement*Speed);
    }
}
