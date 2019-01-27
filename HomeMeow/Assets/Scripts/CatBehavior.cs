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
    public bool playerLeft;
    public bool runAway;

    

    private GameObject player;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        inBoundary = false;
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
        else if (inBoundary == false) //reach player
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
            if (!source.isPlaying)
            {
                source.PlayOneShot(Steps[Random.Range(0, 1)], 0.7f); //walking
            }
        }


    }
}
