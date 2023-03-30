using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform CameraFollowPoint;  // the object to follow

    void Update()
    {
        // make the Camera look at the Followpoint
        transform.LookAt(CameraFollowPoint);
    }
}
