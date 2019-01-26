using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyBehavior : MonoBehaviour
{
    private GameObject player;
    public float movementSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
}
