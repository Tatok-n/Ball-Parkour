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
    public VisualEffect Boost;
    public Transform ori;

    // Start is called before the first frame update
    void Start()
    {
        Direction = Target.position - transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Boost.SetVector3("Dir", rm.rb.velocity);
        Boost.SetVector3("Boi", Ori.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        Boost.Play();
        if (!IsMulti)
        {
            rm.rb.AddForce(Direction* Strength);
        }
        else
        {
            rm.rb.AddForce(rm.rb.velocity.normalized * Strength);
        }



    }
}
