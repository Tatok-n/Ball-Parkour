using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.VFX;

public class BoostScript : MonoBehaviour
{
    public Revamped_Movement rm;
    public Transform Target;
    private Vector3 Direction;
    public ParticleSystem pr;
    public bool IsMulti;
    public float Strength;
    
    // Start is called before the first frame update
    void Start()
    {
        Direction = Target.position - transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        pr.Play();
        if (!IsMulti)
        {
            rm.rb.AddForce(Direction.normalized * Strength);
        }
        else
        {
            rm.rb.AddForce(rm.rb.velocity.normalized * Strength);
        }



    }
}
