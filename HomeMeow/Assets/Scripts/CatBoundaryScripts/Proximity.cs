using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proximity : MonoBehaviour
{
    CatBehavior myParent;
    // Start is called before the first frame update
    void Start()
    {
        myParent = transform.parent.GetComponent<CatBehavior>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")  && myParent != null)
        {
            myParent.inBoundary = true;
            Debug.Log("In Boundary");
        }

        if (other.gameObject.CompareTag("Repair Kit"))
        {
            myParent.foundSomething = true;
            myParent.source.PlayOneShot(myParent.CatFoundSound, 1);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && myParent != null)
        {
            myParent.inBoundary = false;
            Debug.Log("Out Boundary");
        }
        if (other.gameObject.CompareTag("Repair Kit"))
        {
            myParent.foundSomething = false;
        }
    }
}
