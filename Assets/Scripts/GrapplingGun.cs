using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
   private LineRenderer lr;
   public Vector3 grapplePoint;
   public LayerMask whatIsGrappleable;
   public Transform gunTip, gunTip2, camera, player;
   public float maxDistance, range;
   public float springdef,damperdef,massScaledef,MaxDistanceRed,activeDamper,activeSpring;
   public SpringJoint joint;
   public Vector3 pointlocation;
   public float PredictionSphereCastRadius;
   public Transform PredictionPoint,jointpoint;
   public RaycastHit predictionHit;
   public Vector3 realHitPoint;
   public Rigidbody rb;
   public Revamped_Movement mvmt;
   public LineRenderer lr1, lr2;
   public float SwingForce;
   public GameObject sphereboi,connectedobject;
    public string tag;
    public bool needsrot;
    public GameObject pause;

    void Awake() {
    //lr = GetComponent<LineRenderer>();
    maxDistance = 1000f;
   }

   void Update() {
    CheckForSWingPoints();
    pointlocation = realHitPoint;
    

    if (Input.GetMouseButtonDown(0)) {
        if (!pause.activeSelf)
            {
                StartGrapple();
            }
        
    }
    else if (Input.GetMouseButtonUp(0)) {
        StopGrapple();
    }
    if ((IsGrappling()) && (Input.GetMouseButton(1))) {
        joint.spring = activeSpring;
        joint.damper = activeDamper;
    } 
    
    if ((IsGrappling()) && (lr2.positionCount == 0))
        {
            
            Destroy(sphereboi.GetComponent<SpringJoint>()); //Fixes the issue wtih invisible joints
        }
   }

   
   void LateUpdate() {
    DrawRope();
    if (IsGrappling())
        {
            Vector3 Forward = mvmt.orientation.forward;
            Debug.DrawLine(rb.position, Forward, Color.red);
            rb.AddForce(Forward * SwingForce);
            if (needsrot)
            {
                joint.connectedAnchor = jointpoint.position;
            }
        }
    
   }

    private void CheckForSWingPoints() {
        if (IsGrappling()) return;
        RaycastHit SphereCastHit;
        Physics.SphereCast(camera.position, PredictionSphereCastRadius, camera.forward,
        out SphereCastHit, maxDistance);


        RaycastHit hit;
        Physics.Raycast(camera.position, camera.forward,out hit, maxDistance );
        

        if (hit.point != Vector3.zero) {
            realHitPoint = hit.point;
            connectedobject = hit.collider.gameObject;
            tag = hit.collider.tag;
        }

        else if (SphereCastHit.point != Vector3.zero) {
            realHitPoint = SphereCastHit.point;
        }
        else realHitPoint = Vector3.zero;
        if (hit.distance > range)
        {
            realHitPoint = Vector3.zero;
        }
    }

   void StartGrapple() {
    grapplePoint = realHitPoint;
    if ((grapplePoint == Vector3.zero) || (Vector3.Distance(grapplePoint,player.position)> range)) {
        return;
    }
    joint = player.gameObject.AddComponent<SpringJoint>();
    joint.autoConfigureConnectedAnchor = false;

    if (tag == "RotatorBoi") {
        joint.connectedAnchor = jointpoint.position; //sets the anchor point depending on type of object
            needsrot = true;
    } else{
        joint.connectedAnchor = grapplePoint;
            needsrot = false;
        }


        float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

    // The distance grapple will try to keep from grapplepoint
    joint.maxDistance = distanceFromPoint * 1.15f;
    joint.minDistance = distanceFromPoint * 0.25f;

    //behavior of grapple
    joint.spring = springdef;
    joint.damper = damperdef;
    joint.massScale = massScaledef;

        lr1.positionCount = 2;
        lr2.positionCount = 2;


    }
   

   void DrawRope() {

    if (!joint) return;

        lr2.SetPosition(0, gunTip2.position);
        lr1.SetPosition(0, gunTip.position);
        lr1.SetPosition(1, joint.connectedAnchor);
        lr2.SetPosition(1, joint.connectedAnchor);
        

    }


    void StopGrapple() {
        lr1.positionCount = 0;
        lr2.positionCount = 0;
        Destroy(joint);

   }

   public bool IsGrappling() {
    return joint != null;
   }

   public Vector3 GetGrapplePoint() {
    return grapplePoint;
   }
 
}
