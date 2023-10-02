using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform target;
   private Vector3 offset;

   private void Start() 
   {
    offset = transform.position - target.position;
   }

   private void Update() {
    transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z);
   }

}
