using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyBehavior : MonoBehaviour
{
    private GameObject player;
    public float moveSpeed = 5;
    private bool isPlayerInBlob = false;
    private int distanceFromPlayer = 25; // Needs to be set
    private int threshold = 50; // Minimum distance from when it starts being checked

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        randomNumberGen();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        Chase();
    }

    private bool Chase()
    {
        // Vector3 p = player.transform.position;

        if (isPlayerInBlob)
        {
<<<<<<< HEAD
            transform.LookAt(player.transform);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else if (distanceFromPlayer < threshold) // If distanceFromPlayer is smaller, it keeps running randomNumberGen() until it hits 0, 10% chance
        {
            print("SHIT IS RUNNING");
=======
            Vector3 p = player.transform.position;

            // DO CHASE
            return true;
        }
        else if (distanceFromPlayer < threshold) // If distanceFromPlayer is smaller, it keeps running randomNumberGen() until it hits 0, 10% chance
        {
            isPlayerInBlob = true;
>>>>>>> NPC2
            randomNumberGen();
        }
        /* else if () // If player is in Blob
        {
            isPlayerInBlob = true;
        } */
        else
        {
            return false;
        }
        return false;
    }

    private bool randomNumberGen()
    {
        int min = 0;
        int max = 10; // Upper bound exclusive

        int n = Random.Range(min, max);

        if (n < 1)
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            return true;
        }
        else
        {
            return false;
        }
    }
}
