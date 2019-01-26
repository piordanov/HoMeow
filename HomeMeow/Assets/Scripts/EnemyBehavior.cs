using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private float timeToChangeDirection;
    public bool inBoundary;

    // Start is called before the first frame update
    void Start()
    {
        inBoundary = false;
        Movement();
    }

    // Update is called once per frame
    void Update()
    {
        timeToChangeDirection -= Time.deltaTime;

        if (inBoundary == true) 
        {
            GameObject playerObject = GameObject.Find("Player");
            Vector3 direction = transform.position - playerObject.transform.position;
            direction.Normalize();
            transform.forward = direction;
            timeToChangeDirection = 3f;
            GetComponent<Rigidbody>().velocity = transform.forward * 1f;
        }
        else if (timeToChangeDirection <= 0)
        {
            Movement();
        }
    }



    public void Movement()
    {
        float angle = Random.Range(0f, 360f);
        Quaternion quat = Quaternion.AngleAxis(angle, Vector3.up);
        Vector3 newForward = quat * Vector3.forward;
        newForward.y = 0;
        newForward.Normalize();
        transform.forward = newForward;
        timeToChangeDirection = 3f;
        GetComponent<Rigidbody>().velocity = transform.forward * 4f;
    }
}
