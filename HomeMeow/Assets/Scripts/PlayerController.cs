using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 0.3f;

    private Rigidbody rb3d;

    void Start()
    {
        rb3d = GetComponent<Rigidbody> ();
    }

    void FixedUpdate() 
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis ("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

        rb3d.AddForce(movement * speed);

    }
}
