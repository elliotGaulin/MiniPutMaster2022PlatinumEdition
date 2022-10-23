using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform ballTransform;
    public float rotationSpeed = 5f;
    public Vector3 initialOffset = new Vector3(0, 0.5f, 0);

    private Vector3 offset;

    void Start()
    {
        offset = initialOffset;
        transform.position = new Vector3(ballTransform.position.x + offset.x, ballTransform.position.y + offset.y, ballTransform.position.z + offset.z);
        transform.LookAt(ballTransform);
    }

    void Update()
    {
        Vector3 cameraNewPosition = new Vector3(ballTransform.position.x + offset.x, ballTransform.position.y + offset.y, ballTransform.position.z + offset.z);
        transform.position = cameraNewPosition;
        transform.RotateAround(ballTransform.position, Vector3.up, 20 * Time.deltaTime * rotationSpeed * Input.GetAxis("Horizontal"));
        offset = transform.position - ballTransform.position;
    }
}
