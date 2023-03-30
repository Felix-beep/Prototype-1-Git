using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPoint : MonoBehaviour
{
    [SerializeField]
    private VehicleController VehicleController; // Object to get the Speed and Transform from
    private Transform FollowObject; // Object to Follow

    private float Speed; // current speed of the object
    private Vector3 DistanceVector; // the calculated desired distance from the object 


    private float smoothSpeed = 0.125f;  // the smoothing factor

    private void Start()
    {
        FollowObject = VehicleController.transform;   
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Speed = VehicleController.CurrentSpeed;

        if (Speed < 19f)
        {
            // while accelerating move the followpoint away from the vehicle
            DistanceVector = new Vector3(0, 0, -Speed / 4);
        }
        else
        {
            // at max speed let the followpoint get closer to the vehicle
            if (DistanceVector.z < 0)
            {
                DistanceVector.z += 0.5f * Time.deltaTime;
            }
            else
            {
                DistanceVector.z = 0;
            }
        }


        // calculate the desired position of the followpoint
        Vector3 desiredPosition = FollowObject.position + DistanceVector;

        // smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
