using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapOntoItemBar : MonoBehaviour
{
    public GameObject ItemBar;
    public Transform POV;
    public Vector3 RotationOffset;

    void Start()
    {
        Vector3 POVpoint = POV.GetComponent<Transform>().position;
        Collider Mesh = ItemBar.GetComponent<Collider>();
        Vector3 MeshLocation = ItemBar.GetComponent<Transform>().position;
        Quaternion rotation =  ItemBar.GetComponent<Transform>().rotation;

        Vector3 pointToSnapon = Physics.ClosestPoint(POVpoint,Mesh,MeshLocation,rotation);

        gameObject.GetComponent<Transform>().position = pointToSnapon;

        Vector3 SnappingAngle = POV.GetComponent<Transform>().eulerAngles;

        gameObject.GetComponent<Transform>().eulerAngles = SnappingAngle;

        Vector3 lastPoint = pointToSnapon;
        Vector3 lastRot = SnappingAngle;


    }

    void Update()
    {
        Vector3 POVpoint = POV.GetComponent<Transform>().position;
        Collider Mesh = ItemBar.GetComponent<Collider>();
        Vector3 MeshLocation = ItemBar.GetComponent<Transform>().position;
        Quaternion rotation =  ItemBar.GetComponent<Transform>().rotation;

        Vector3 pointToSnapon = Physics.ClosestPoint(POVpoint,Mesh,MeshLocation,rotation);
        Vector3 SnappingAngle = POV.GetComponent<Transform>().eulerAngles;

        Vector3 lastPoint = pointToSnapon;
        Vector3 lastRot = SnappingAngle;

        Vector3 offset = pointToSnapon-MeshLocation;

        pointToSnapon -= 2*offset;
        
        gameObject.GetComponent<Transform>().position = pointToSnapon;

        SnappingAngle += RotationOffset;
        
        if (lastRot.x + SnappingAngle.x + lastRot.y + SnappingAngle.y + lastRot.z + SnappingAngle.z >10) {
        gameObject.GetComponent<Transform>().eulerAngles = SnappingAngle;
        }

    }
}
