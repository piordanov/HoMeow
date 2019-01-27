using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehavior : MonoBehaviour
{

    public float movementSpeed = 4;
    public bool inBoundary;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        inBoundary = false;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (inBoundary == false)
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
    }
}
