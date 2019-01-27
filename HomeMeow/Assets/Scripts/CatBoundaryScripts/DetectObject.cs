using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObject : MonoBehaviour
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
        if (other.gameObject.CompareTag("Repair Kit"))
        {
            myParent.nearbyKit = true;
            myParent.nearestRepairKit = other.gameObject;
            // myParent.source.PlayOneShot(myParent.CatFollowMeSound);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            myParent.playerLeft = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Repair Kit"))
        {
            myParent.nearbyKit = false;
            myParent.nearestRepairKit = other.gameObject;
            Debug.Log("Out Boundary for repair kit");
        }
        if (other.gameObject.CompareTag("Player"))
        {
            myParent.playerLeft = true;
        }
    }
}
