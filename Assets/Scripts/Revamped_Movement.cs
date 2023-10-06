using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Revamped_Movement : MonoBehaviour
{
    public  Rigidbody rb;
    public float Speed;
    public float BoostValue;
    public float movementX;
    public float movementY;
    public Transform orientation;
    public int MaxBoosts;
    public int boostsY;
    public int boostsX;
    public int refresh;
    public int timerX;
    public int timerY;
    public bool BoostY;
    public bool BoostX;
    public float[] parametersX = new float[2];
    public float[] parametersY = new float[2];
    public int[] BoostUpdaterX = new int[2];
    public int[] BoostUpdaterY = new int[2];



    // Start is called before the first frame update
    void Start()
    {
        BoostX = true;
        BoostY = true;
        timerX = timerY = refresh;
    }

    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    float[] BoostManager (float Direction1, float Direction2, bool Boost, int counter)
    {
        if (counter==0 || (!Boost && Direction1 != 0)) // No update, either is moving and Boostcondition updated, or has no boosts
        {
            return new[] { 0f, 2f };
        } else if (!Boost && Direction1==0) //is not moving, needs to be able to boost
        {
            return new[] { 0f, 1f };
        } else if ((Direction2==0) & (Boost) & (Direction1!= 0)) // is gonna start moving, needs boost
        {
            return new[] { Direction1*BoostValue, 0f };
        }
        return new[] { 0f, 2f };
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }


    int[] BoostTimer(float Boostparam, int NumBoosts, int timer) //return Boosts, timer updates
    {
       
        if (Boostparam != 0) // Did a boost, has boosts remaining
        {
            return new[] { -1, 0 };
        } else if (NumBoosts < MaxBoosts && timer < refresh) { // Can't add boosts, update timer
            return new[] { 0, 1 }; }
        else if (NumBoosts < MaxBoosts && timer >= refresh) {// Can Add boosts
            return new[] { 1, -timer }; }
        
        return new[] { 0, 2 };
    
    }

    private void FixedUpdate()
    {
        
        Vector3 Forward = orientation.right; //right is forward for some reason, change later on 
        Vector3 Right = orientation.forward;
        Forward.y = 0f;
        Right.y = 0f;
        
        //float[] parametersX = new float[2];
        parametersX = BoostManager(movementX, movementY, BoostX, boostsX);
        if (parametersX[1] != 2)
        {BoostX = Convert.ToBoolean(parametersX[1]);}
        BoostUpdaterX = BoostTimer(parametersX[0], boostsX, timerX);
        if (BoostUpdaterX[1] !=2) {
            timerX += BoostUpdaterX[1];
            boostsX += BoostUpdaterX[0];
        }

        parametersY = BoostManager(movementY, movementX, BoostY, boostsY);
        if (parametersY[1] != 2)
        { BoostY = Convert.ToBoolean(parametersY[1]); }
        BoostUpdaterY = BoostTimer(parametersY[0], boostsY, timerY);
        if (BoostUpdaterY[1] != 2)
        {
            timerY += BoostUpdaterY[1];
            boostsY += BoostUpdaterY[0];
        }

        Vector3 movement = (movementX+parametersX[0])*Forward+ (movementY + parametersY[0]) * Right;
        Debug.DrawLine(rb.position, rb.position + movement);
        rb.AddForce(movement*Speed);
    }
}
