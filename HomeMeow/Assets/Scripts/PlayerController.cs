using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float movementspeed = 1f;


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementspeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, movementspeed * Input.GetAxis("Vertical") * Time.deltaTime);

    }

    void OnTriggerExit(Collider other)
    {

    }


    void OnTriggerEnter(Collider other)
    {
        
    }


}
