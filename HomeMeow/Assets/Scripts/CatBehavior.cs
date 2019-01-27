using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehavior : MonoBehaviour
{

    public float movementSpeed = 4;
    public bool inBoundary;
    public bool nearbyKit;
    public bool foundSomething;
    public bool playerLeft;
    public bool enemyDetected;
    public bool runAway;
    public GameObject nearestRepairKit;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        inBoundary = false;
        nearbyKit = false;
        playerLeft = false;
        runAway = false;

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (runAway)
        {
            movementSpeed = 8;
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
        else if (enemyDetected) //cat is scared of enemy, run away to player
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
        else if (nearbyKit && !playerLeft) //found a kit with player in vicinity
        {
            if (foundSomething == true)
            {
                transform.LookAt(player.transform);

            }
            else
            {
                transform.LookAt(nearestRepairKit.transform);
                transform.position += transform.forward * movementSpeed * Time.deltaTime;
            }

        }
        else if (inBoundary == false) //reach player
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }


    }
}
