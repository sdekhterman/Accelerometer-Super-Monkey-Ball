using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCam : MonoBehaviour
{
    public GameObject dog;
    private Vector3 offset;
    public int speed = 5;

    void Start()
    {
        offset = transform.position - dog.transform.position;
    }

    void LateUpdate()
    {
        transform.position = dog.transform.position / speed + offset;
    }
}