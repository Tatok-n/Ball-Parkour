using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
    public Revamped_Movement rm;
    public Transform Target;
    public Transform Normal;
    public float Strength;
    private Vector3 NormalVect;
    private Vector3 Direction;
    public ParticleSystem pr;
    // Start is called before the first frame update
    void Start()
    {
        Direction = Target.position - transform.position;
        NormalVect = Normal.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        pr.Play();
        if (rm.isGrounded)
        {
            rm.rb.AddForce(Direction.normalized*Strength);
        } else {
            rm.rb.AddForce(Vector3.Reflect(rm.rb.velocity, NormalVect) *Strength);
        }



    }
}
