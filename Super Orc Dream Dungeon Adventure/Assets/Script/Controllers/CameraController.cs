﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool useOffsetValues;

    private void Start()
    {
        if (!useOffsetValues)
        { 
         offset = target.position - transform.position;
        }
    }

    private void Update()
    {

        transform.position = target.position - offset;

        transform.LookAt(target);
    }


    /*
    public Transform target;

    
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public float pitch = 2f;

    //yaw was for rotating the camera
    //public float yawSpeed = 100f;

    //private float currentYaw = 0f;
    private float currentZoom = 10f;
    
    private void Update()
    {
        
       currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
       currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
       //currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
       
    }

    
    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        //transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
    */
}
