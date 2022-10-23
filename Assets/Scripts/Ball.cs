using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class Ball : MonoBehaviour
{
    Rigidbody rigidBody;
    public Transform mainCameraTransform;
    public UnityEvent OnBallHit;


    [Header("InputForce")]
    public float force;
    public float forceSensitivity;
    public float minForce;
    public float maxForce;

    private bool waitForHit = false;

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
            force += Input.GetAxis("Vertical") * Time.deltaTime * forceSensitivity;
            if(force > maxForce)
            {
                force = maxForce;
            } else if (force < minForce)
            {
                force = minForce;
            }
            Debug.Log(force);
        }


        if (CanHit())
        {
            Hit();
        }
    }

    private bool CanHit()
    {
        return Input.GetAxis("Jump") > 0f && rigidBody.velocity.magnitude == 0f && !waitForHit;
    }

    private void Hit()
    {
        rigidBody.AddForce(new Vector3(mainCameraTransform.forward.x, 0, mainCameraTransform.forward.z) * force, ForceMode.Impulse);
        OnBallHit?.Invoke();
        StartCoroutine(HitDelay());
    }

    private IEnumerator HitDelay()
    {
        waitForHit = true;
        yield return new WaitForSeconds(0.5f);
        waitForHit = false;
    }
}
