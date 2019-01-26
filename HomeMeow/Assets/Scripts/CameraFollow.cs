using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Position that camera will follow
    public float smoothing = 5f;  // The smoothness of camera movement

    Vector3 offset;             //Initial offset #endregion

    void Start()
    {
        // Calculate the initial offset.
        offset = transform.position - target.position;
    }

    void FixedUpdate ()
    {
        // Create camera position based on the offset from the target.
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp (transform.position, targetCamPos,smoothing * Time.deltaTime);
    }

}
