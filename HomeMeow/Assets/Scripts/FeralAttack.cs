using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeralAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 2.5f;         // Seconds between attack
    public int attackDamage = 1;                    // Amount of damage deducted from total health per attack


    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange;                            // Whether player is in range with trigger collider
    float timer;                                    // Timer that counts time before next attack


    // Start is called before the first frame update
    void Awake ()
    {
        //Set up references
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent<PlayerHealth> ();
    }

    void OnTriggerEnter (Collider other)
    {
        //If the entering collider is the player...
        if(other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("isthisworking");
            //... player is in range
            playerInRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        // If the exiting collider is the player...
        if(other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("Player no long er in range.");
            //...player is no longer in range
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Add time since Update was called to timer
        timer += Time.deltaTime;
        // Debug.Log(playerInRange);
        // Debug.Log(timer >= timeBetweenAttacks);
        //If the timer exceeds the time between attacks, player is in range, and feral cat is still alive...
        if((timer >= timeBetweenAttacks) && playerInRange)
        {
            Debug.Log("attack()");
            //... attack.
            Attack ();
        }
    }

        // if the player has zero or less health

        
        void Attack ()
        {
            //Reset timer
            timer = 0f;

            //If player has health to lose...
            // Debug.Log("Trying to attack player");
            if(playerHealth.currentHealth > 0)
            {
                gameObject.GetComponent<FeralCatBehavior> ().runAway = true;
            // Debug.Log(" attacked player");
                //...damage the player.
                playerHealth.TakeDamage (attackDamage);
            }
        }
    
}
