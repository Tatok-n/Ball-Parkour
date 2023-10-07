using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Revamped_Movement : MonoBehaviour
{
    public  Rigidbody rb;
    public float Speed;
    public float Velocity;
    public int JumpForce;
    public Transform Spherepoint;
    public float BoostValue;
    private float movementX;
    private float movementY;
    public Transform orientation;
    public int MaxBoosts;
    public int boostsY;
    public int boostsX;
    public int refresh;
    public int timerX;
    public int timerY;
    public bool BoostY;
    public bool BoostX;
    private float[] parametersX = new float[2];
    private float[] parametersY = new float[2];
    private int[] BoostUpdaterX = new int[2];
    private int[] BoostUpdaterY = new int[2];
    private int[] BurtParam = new int[2];
    public PlayerInput beep;
    public bool burstmode;
    public int burstTimer;
    public int Bursts;
    public int burstForce;
    public float burstval;
    public Vector3 LockPosition;
  

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
    
    void OnJump()
    {
        rb.AddForce(orientation.up*(JumpForce*Velocity*0.5f));
    }

    
    void OnBurst(InputValue BurstValue)
    {
        
        burstval = BurstValue.Get<float>();
        if (Bursts==0)
        {
            burstval = 0;
        }
        if (burstval == 1)
        {
            LockPosition = transform.position;
            burstmode = true;
        }
        
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
        
        Collider[] hitColliders = Physics.OverlapSphere(Spherepoint.position, 0.53f); //Checks for any touching walls
        int important = 0;
        foreach (Collider col in hitColliders)
        {
            if (col.tag == "Ground")
            {important += 1; }
        }
        if (important > 0)
        {
            JumpForce = 150;
            Speed = 5f;
        }
        else
        {
            JumpForce = 0;
            Speed = 1f;
        }
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

    int[] BurstTimer(int num, int counter)
    {
        if (num == 3)
        {
            return new[] { 0, 2 };
        } else if (num<3 & counter>=120)
        {
            return new[] { 1, -counter };
        } else if (num < 3 & counter < 120)
        {
            return new[] { 0, 1 };
        }
        return new[] { 0, 2 };
    }

    private void FixedUpdate()
    {
        BurtParam = BurstTimer(Bursts, burstTimer);
        if (BurtParam[1]!=2)
        {
            Bursts += BurtParam[0];
            burstTimer += BurtParam[1];
        }
        if (burstmode)
        {
            
            transform.position = LockPosition;
            rb.velocity /= 5;
            

            if (burstval == 0f)
            {
                Bursts -= 1;
                rb.AddForce(orientation.forward * burstForce);
                burstmode = false;
                return;
            }
            return;
        }
        Velocity = rb.velocity.magnitude;
        Vector3 Forward = orientation.right; //right is forward for some reason, change later on 
        Vector3 Right = orientation.forward;
        Forward.y = 0f;
        Right.y = 0f;
        
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
              
        rb.AddForce(movement*Speed);
    }

    private void LateUpdate()
    {
        
        
    }
}
