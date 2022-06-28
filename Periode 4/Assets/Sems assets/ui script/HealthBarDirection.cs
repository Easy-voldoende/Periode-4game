using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarDirection : MonoBehaviour
{
    public GameObject cameraToLookAt;
    
    void Update()
    {
        cameraToLookAt = GameObject.Find("Main Camera");
        Vector3 v = cameraToLookAt.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(cameraToLookAt.transform.position - v);
        transform.Rotate(0, 180, 0);
    }
}
