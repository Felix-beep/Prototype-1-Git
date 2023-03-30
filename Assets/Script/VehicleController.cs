using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [SerializeField]
    private int MaxSpeed = 20;
    [SerializeField]
    private int Acceleration = 4;

    public float CurrentSpeed = 0;

    // Update is called once per frame
    void Update()
    {
        // acceleration
        CurrentSpeed += Acceleration * Time.deltaTime;
        if (CurrentSpeed > MaxSpeed) CurrentSpeed = MaxSpeed;

        // apply forward movement
        transform.Translate(Vector3.forward * CurrentSpeed * Time.deltaTime);
    }
}
