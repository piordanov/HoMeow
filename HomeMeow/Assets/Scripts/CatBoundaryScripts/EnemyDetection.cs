using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
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
        if (other.gameObject.CompareTag("Enemy"))
        {
            myParent.source.PlayOneShot(myParent.EnemyDetectedSound, 1);
            myParent.enemyDetected = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            myParent.enemyDetected = false;
        }
    }
}
