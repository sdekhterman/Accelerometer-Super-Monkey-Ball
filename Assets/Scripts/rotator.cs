using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rotate an object around its Y (upward) axis in response to
// left/right controls.
public class rotator : MonoBehaviour
{
    public Rigidbody level;
    public float accelx, accelz = 0;
    public float speed = 2;

    void Start()
    {
        level = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        accelx = Input.acceleration.y;
        accelz = -Input.acceleration.x;
        level.transform.Rotate(speed * accelx * Time.deltaTime, 0, speed * accelz * Time.deltaTime);
    }
}
