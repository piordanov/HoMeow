using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 7f;
    private Rigidbody rb3d;
    private Vector3 movement;

    void Start()
    {
        rb3d = GetComponent<Rigidbody> ();
    }

    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxisRaw ("Vertical");

        Move(moveHorizontal, moveVertical);

    }

    void Move (float moveHorizontal, float moveVertical)
    {
        movement.Set(moveHorizontal, 0f, moveVertical);
        movement = movement.normalized * speed * Time.deltaTime;

        rb3d.MovePosition(transform.position + movement);
    }

    void OnTriggerExit(Collider other)
    {

    }

    void OnTriggerEnter(Collider other)
    {

    }
}
