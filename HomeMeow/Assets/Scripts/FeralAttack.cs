using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeralAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;         // Seconds between attack
    public int attackDamage = 1;                    // Amount of damage deducted from total health per attack


    Animator anim;
    GameObject player;
    FeralHealth feralHealth;                        // Reference to feral cat health
    bool  playerInRange;                            // Whether player is in range with trigger collider
    float timer;                                    // Timer that counts time before next attack


    // Start is called before the first frame update
    void Awake ()
    {
        //Set up references
        player = GameObject.FindGameObjectWithTag ("Player");
        PlayerHealth = player.GetComponent <PlayerHealth> ();
        feralHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator>;
    }

    void OnTriggerEnter (Collider other)
    {
        //If the entering collider is the player...
        if(other.gameObject == player)
        {
            //... player is in range
            playerInRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        // If the exiting collider is the player...
        if(other.gameObject == player)
        {
            //...player is no longer in range
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Add time since Update was called to timer
        timer += time.deltaTime;

        //If the timer exceeds the time between attacks, player is in range, and feral cat is still alive...
        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            //... attack.
            Attack ();
        }

        // if the player has zero or less health

        if(PlayerHealth.currentHealth <= 0)
        {
            //...tell animator player is dead
            anim.SetTrigger ("PlayerDead");
        }
        
        void Attack ()
        {
            //Reset timer
            timer = 0f;

            //If player has health to lose...

            if(PlayerHealth.currentHealth > 0)
            {
                //...damage the player.
                PlayerHealth.TakeDamage (attackDamage);
            }
        }
    }
}
