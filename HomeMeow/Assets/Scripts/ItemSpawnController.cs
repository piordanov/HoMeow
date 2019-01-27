using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemSpawnController : MonoBehaviour
{
    private GameObject player;
    public int index; // what type of object to obtain

    float bobSpeed = 2f;
    float rotSpeed = 40f;
    float height = 0.5f;

    void Start() 
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
        Vector3 pos = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InventoryController inventory = player.GetComponent<InventoryController> ();
            inventory.AddItem(index);
            Destroy(gameObject);
        }
    }

}
