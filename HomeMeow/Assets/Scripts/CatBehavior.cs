using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehavior : MonoBehaviour
{

    public float movementSpeed = 4;
    public bool inBoundary;
    public bool nearbyKit;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        inBoundary = false;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        if (inBoundary == false)
        {
            
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
    }
}
