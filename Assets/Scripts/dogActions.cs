using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogActions : MonoBehaviour
{
    public Transform respawn;
    private Rigidbody rb;
    public int jumpForce;
    public int jumpCount;
    public int jumpLimit = 3;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch jump = Input.GetTouch(0);

            if (jump.phase == TouchPhase.Began && jumpCount <= jumpLimit)
            {
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                jumpCount++;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            jumpReset();
        }
        else if (other.gameObject.CompareTag("Net"))
        {
            transform.position = respawn.position;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            jumpReset();
        }        
    }

    void jumpReset()
    {
        jumpCount = 0;
    }
}
