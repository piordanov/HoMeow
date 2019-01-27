using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehavior : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] Steps;
    public AudioClip EnemyDetectedSound;
    public AudioClip CatFollowMeSound;
    public AudioClip CatFoundSound;

    public float movementSpeed = 4;
    public bool inBoundary;
    public bool nearbyKit;
    public bool foundSomething;
    public bool playerLeft;
    public bool enemyDetected;
    public bool runAway;
    public bool saved = false;
    public GameObject nearestRepairKit;

    

    private GameObject player;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        inBoundary = false;
        nearbyKit = false;
        playerLeft = false;
        runAway = false;

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (runAway)
        {
            movementSpeed = 8;
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
        else if (enemyDetected) //cat is scared of enemy, run away to player
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
            // if (!source.isPlaying)
            // {
            //     source.PlayOneShot(Steps[Random.Range(0, 1)], 0.7f); //walking
            // }
        }
        else if (nearbyKit && !playerLeft) //found a kit with player in vicinity
        {
            if (foundSomething == true)
            {
                transform.LookAt(player.transform);
            }
            else
            {
                transform.LookAt(nearestRepairKit.transform);
                transform.position += transform.forward * movementSpeed * Time.deltaTime;
                // if (!source.isPlaying)
                // {
                //     source.PlayOneShot(Steps[Random.Range(0, 1)], 0.7f); //walking
                // }
            }

        }
        else if (inBoundary == false) //reach player
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
            // if (!source.isPlaying)
            // {
            //     source.PlayOneShot(Steps[Random.Range(0, 1)], 0.7f); //walking
            // }
        }


    }
}
