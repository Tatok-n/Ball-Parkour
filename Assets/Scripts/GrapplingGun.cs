using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
   private LineRenderer lr;
   private Vector3 grapplePoint;
   public LayerMask whatIsGrappleable;
   public Transform gunTip, camera, player;
   private float maxDistance;
   public float springdef,damperdef,massScaledef,MaxDistanceRed,activeDamper,activeSpring;
   private SpringJoint joint;
   public Vector3 pointlocation;
   public float PredictionSphereCastRadius;
   public Transform PredictionPoint;
   public RaycastHit predictionHit;
   public Vector3 realHitPoint;

   void Awake() {
    lr = GetComponent<LineRenderer>();
    maxDistance = 1000f;
   }

   void Update() {
    CheckForSWingPoints();
    pointlocation = realHitPoint;
    

    if (Input.GetMouseButtonDown(0)) {
        StartGrapple();
    }
    else if (Input.GetMouseButtonUp(0)) {
        StopGrapple();
    }
    if ((IsGrappling()) && (Input.GetMouseButton(1))) {
        joint.spring = activeSpring;
        joint.damper = activeDamper;
    } 
   }

    
   void LateUpdate() {
    DrawRope();
    
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
        }

        else if (SphereCastHit.point != Vector3.zero) {
            realHitPoint = SphereCastHit.point;
        }

        else realHitPoint = Vector3.zero;

    }

   void StartGrapple() {
    grapplePoint = realHitPoint;
    if (grapplePoint == Vector3.zero) {
        return;
    }
    joint = player.gameObject.AddComponent<SpringJoint>();
    joint.autoConfigureConnectedAnchor = false;
    joint.connectedAnchor = grapplePoint;

    float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);
    // The distance grapple will try to keep from grapplepoint
    joint.maxDistance = distanceFromPoint * 0.8f;
    joint.minDistance = distanceFromPoint * 0.25f;

    //behavior of grapple
    joint.spring = springdef;
    joint.damper = damperdef;
    joint.massScale = massScaledef;

    lr.positionCount = 2;


   }
   

   void DrawRope() {

    if (!joint) return;

    lr.SetPosition(0, gunTip.position);
    lr.SetPosition(1, grapplePoint);
   }

   

   void StopGrapple() {
    lr.positionCount = 0;
    Destroy(joint);

   }

   public bool IsGrappling() {
    return joint != null;
   }

   public Vector3 GetGrapplePoint() {
    return grapplePoint;
   }
 
}
