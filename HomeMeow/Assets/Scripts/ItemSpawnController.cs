using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemSpawnController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onAquired;

    float bobSpeed = 2f;
    float rotSpeed = 3f;
    float height = 0.5f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime);
        Vector3 pos = transform.position;
        float newY = Mathf.Sin(Time.time * bobSpeed);
        transform.position = new Vector3(pos.x, newY, pos.z) * height;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onAquired.Invoke();

            //add 1 to counter

            //destroy gameobject
        }
    }

}
