using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyBehavior : MonoBehaviour
{
    private GameObject player;
    public float movementSpeed = 5;
    private bool attack;
    private bool isPlayerInBlob = false;
    private int distanceFromPlayer = 25; // Needs to be set
    private int threshold = 50; // Minimum distance from when it starts being checked

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        randomNumberGen();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    private bool Chase()
    {
        if (isPlayerInBlob)
        {
            Vector3 p = player.transform.position;
            return true;
        }
        else if (distanceFromPlayer < threshold) // If distanceFromPlayer is smaller, it keeps running randomNumberGen() until it hits 0, 10% chance
        {
            randomNumberGen();
        }
        else
        {
            return false;
        }
        return false;
    }

    private bool randomNumberGen()
    {
        int min = 0;
        int max = 10; // Upper bound not included on Next() according to C# docs
        // https://docs.microsoft.com/en-us/dotnet/api/system.random.next?view=netframework-4.7.2

        int n = Random.Range(min, max);

        if (n < 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
