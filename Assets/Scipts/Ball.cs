using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rigidBody;
    public Transform mainCameraTransform;
    public float force;

    public delegate void ShootEventHandler();
    public event ShootEventHandler ShotFired;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0f)
        {
            force += Input.GetAxis("Vertical") * Time.deltaTime / 10f;
            Debug.Log(force);
        }

        if (rigidBody.velocity.magnitude == 0f)
        {
            if (Input.GetAxis("Jump") > 0f && rigidBody.velocity.magnitude == 0f)
            {
                rigidBody.AddForce( new Vector3(mainCameraTransform.forward.x, 0, mainCameraTransform.forward.z) * force, ForceMode.Impulse);
            }
        }
    }
}
