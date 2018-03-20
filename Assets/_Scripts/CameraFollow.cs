﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public float smoothSpeed = 0.25f;

    public Vector3 offset;

    public bool canCameraMove = true;

    TimeBody timeBody;

    Vector3 desiredPosition;

    private void Start()
    {
        timeBody = FindObjectOfType<TimeBody>();
        transform.position = target.position + offset;
    }

    void FixedUpdate ()
    {
        if(canCameraMove  /*!timeBody.isRewing*/)
        {
            desiredPosition = target.position + offset;
            
        }
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;
    }
}