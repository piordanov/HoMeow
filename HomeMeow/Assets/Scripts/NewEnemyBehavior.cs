using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyBehavior : MonoBehaviour
{
    private GameObject player;
    public int moveSpeed = 5;
    private int distanceFromPlayer = 1;
    private int threshold = 25; // Maximum distance, technically. *Nicky Young gif*

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
    }

    private void Chase()
    {
        if (distanceFromPlayer < threshold)
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
