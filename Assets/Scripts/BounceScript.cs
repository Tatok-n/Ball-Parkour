using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.VFX;

public class BounceScript : MonoBehaviour
{
    public Revamped_Movement rm;
    public Transform Target;
    public Transform Normal;
    public float Strength;
    private Vector3 NormalVect;
    private Vector3 Direction;
    public ParticleSystem pr;
    public VisualEffect BounceBoost;
    // Start is called before the first frame update
    void Start()
    {
        Direction = Target.position - transform.position;
        NormalVect = Normal.position - transform.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        BounceBoost.SetVector3("Pos", rm.transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        BounceBoost.Play();
        rm.rb.AddForce(Direction.normalized*Strength);
        



    }
}
