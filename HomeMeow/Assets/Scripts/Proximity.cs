using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proximity : MonoBehaviour
{
    EnemyBehavior myParent;
    // Start is called before the first frame update
    void Start()
    {
        myParent = transform.parent.GetComponent<EnemyBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            myParent.inBoundary = true;
            Debug.Log("In Boundary");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            myParent.inBoundary = false;
            Debug.Log("Out Boundary");
        }
    }
}
