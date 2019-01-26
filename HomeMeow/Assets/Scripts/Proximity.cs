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
            myParent.runAway = true;
            Debug.Log("runAway");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            myParent.runAway = false;
            Debug.Log("you good");
        }
    }

}
