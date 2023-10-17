using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockToItembar : MonoBehaviour
{
    
    public Transform POV;
    public float pastY, NewY, Change;
    public Vector3 OldAngles,offset;
    // Start is called before the first frame update
    void Start()
    {
        
        pastY = POV.eulerAngles.y;
        OldAngles = transform.eulerAngles;
        
    }

    // Update is called once per frame
    void Update()
    {

        NewY = POV.eulerAngles.y;
        Change = NewY - pastY;
        OldAngles.y += Change;
        Vector3 FinalAngle = new Vector3(offset.x + OldAngles.x, offset.y + OldAngles.y, offset.z+OldAngles.z);
        transform.localEulerAngles = FinalAngle;
        pastY = POV.eulerAngles.y;
        

    }
}
