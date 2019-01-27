using UnityEngine;
using UnityEngine.UI;
using System.Collections;




public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 3;        //Total starting health
    public int currentHealth;               //Current amount of player health    public Image damageImage;               //Image that flashes on screen when taking damage


    public Image damageImage;
    public AudioClip deathClip;             //Audio clip that plays when player dies
    public float flashSpeed = 5f;           //The speed that the damageImage will fade
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f); //The colour the damageImage will flash

    AudioSource playerAudio;                //References AudioSource component.
    PlayerController playerController;          //References player's movement
    bool isDead;                            //Whether player is dead.
    bool damaged;                           //True when player gets damaged.

    // Start is called before the first frame update
    void Awake ()
    {
        //Reference setup

        playerAudio = GetComponent <AudioSource>();
        playerController = GetComponent <PlayerController>();

        //Set initial health
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //If player takes damage
        if(damaged)
        {
            //...set color of damageImage to flash color
            //damageImage.color = flashColour;
        }
        //Otherwise...
        else
        {
            //...transition color back to clear
            //damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        //Reset the damaged flag.

        damaged = false;
    }

    public void TakeDamage (int amount)
    {
        Debug.Log("des");
        //Set the damaged flag so screen will flash
        damaged = true;

        //Reduce current health by damage amount
        currentHealth -= amount;

        //Play hurt sound effect
        if(playerAudio != null) {
            playerAudio.Play ();
        }
        

        //If the player has lost all it's health and the death flag hasn't been set
        if(currentHealth <= 0 && !isDead)
        {
            //then kill player
            Death();
        }
    }

    void Death ()
    {
        Destroy(gameObject);
        Debug.Log("U r ded");
        //Set the death flag so this function won't be recalled
        isDead = true;

        //Turn off any shooting effects

        //Set the audiosource to play the death clip and play it (this will stop hurt sound)
        playerAudio.clip = deathClip;
        playerAudio.Play ();

        //Turn off movement and shooting
        playerController.enabled = false;
    }
}
