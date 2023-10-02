using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   public float speed = 5f;
   private Rigidbody rigid;
   public Transform orientation;
   public Transform ground;
   public float ogDrag = 0.3f;
   public int JumpCount = 1;
   public Collider legs;
   public float JumpMultiplier=30;
   public float PhysicalSpeed;
   public bool IsGrounded;
   public float DashMultiplier = 100f;
   public Vector3 origin;
   public float CurrSpeed;
   public Vector3 lastLocation;
   
   

    private void Start() {
        rigid = gameObject.GetComponent<Rigidbody>();
        IsGrounded = true;
        origin = gameObject.GetComponent<Transform>().position;
        lastLocation = gameObject.GetComponent<Transform>().position;

    }

    private void GetCurrSpeed() {
        float distance = Vector3.Distance(lastLocation, transform.position);
        CurrSpeed = distance/Time.deltaTime;
        lastLocation = transform.position; 
    }

    private void OnCollisionEnter(Collision collision) //later implement tags to ignore walls and etc
    {
        ground = collision.gameObject.transform;
        JumpCount =2;
        IsGrounded = true;
        Debug.Log(IsGrounded);
    }

    private void OnCollisionExit(Collision collision) {
        IsGrounded = false;
        Debug.Log(IsGrounded);
    }

    public void Respawn() {
        gameObject.GetComponent<Transform>().position = origin;
    }

    public Vector3 projectOnGround(Vector3 dir) {
        return Vector3.ProjectOnPlane(dir,ground.up);
    }

    

   private void FixedUpdate()
   {
    PhysicalSpeed = speed*Time.deltaTime;
    GetCurrSpeed();
    //Debug.Log(CurrSpeed);

    if (Input.GetKeyDown(KeyCode.RightControl)) {
        Respawn();
    }
    
    if (IsGrounded) { //ground movement;
        if (Input.GetAxis("Horizontal")>0)
        {
            rigid.AddForce(projectOnGround(orientation.right)*PhysicalSpeed);
            
        }

        if (Input.GetAxis("Horizontal")<0)
        {
            rigid.AddForce(projectOnGround(-orientation.right)*PhysicalSpeed);
        }

        if (Input.GetAxis("Vertical")<0)
        {
            rigid.AddForce(projectOnGround(-orientation.forward)*PhysicalSpeed);
        }

        if (Input.GetAxis("Vertical")>0)
        {
            rigid.AddForce(projectOnGround(orientation.forward)*PhysicalSpeed);
        }

        if (Input.GetKey("left shift")) { //Sprint mechanic
            rigid.drag= ogDrag/3.0f;
        } else if(Input.GetKey("left ctrl")) {
            rigid.drag = ogDrag/0.1f;
        } else {
            rigid.drag = ogDrag;
        }
        if (Input.GetKeyDown(KeyCode.Space) && JumpCount > 0) {

            rigid.AddForce(ground.up * PhysicalSpeed * JumpMultiplier*CurrSpeed*0.25f);
            JumpCount-=1;
            legs.enabled = true;

        
        } else {
            legs.enabled = false;
             }

        }
    else {
        bool locked = false;
        if (Input.GetKeyDown(KeyCode.Q) && !locked) {
            rigid.AddForce(-orientation.right *PhysicalSpeed * DashMultiplier);
            locked = true;
        } else if (Input.GetKeyDown(KeyCode.E) && !locked) {
            rigid.AddForce(orientation.right *PhysicalSpeed * DashMultiplier);
            locked = true;
        } else if (Input.GetKeyDown("left shift") && !locked) {
            rigid.AddForce(orientation.forward *PhysicalSpeed * DashMultiplier);
            locked = true;
        }
        if (locked) {
            if (Input.GetKeyUp(KeyCode.Q) ||Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp("left shift")) {
                locked = false;
            }
        }

    }
    
   }
}
