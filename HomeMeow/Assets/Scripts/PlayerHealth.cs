using UnityEngine;
using UnityEngine.UI;
using System.Collections;




public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;        //Total starting health
    public int currentHealth;               //Current amount of player health
    public Slider healthSlider;             //References the UI image of health
    public Image damageImage;               //Image that flashes on screen when taking damage

    public AudioClip deathClip;             //Audio clip that plays when player dies
    public float flashSpeed = 5f;           //The speed that the damageImage will fade
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f); //The colour the damageImage will flash

    public Animator anim;                          //Reference to animator component
    public AudioSource playerAudio;                //References AudioSource component.
    public PlayerController playerController;          //References player's movement
    bool isDead;                            //Whether player is dead.
    bool damaged;                           //True when player gets damaged.

    // Start is called before the first frame update
    void Awake ()
    {
        //Reference setup

        anim = GetComponent <Animator>();
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
            damageImage.color = flashColour;
        }
        //Otherwise...
        else
        {
            //...transition color back to clear
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        //Reset the damaged flag.

        damaged = false;
    }

    public void TakeDamage (int amount)
    {
        //Set the damaged flag so screen will flash
        damaged = true;

        //Reduce current health by damage amount
        currentHealth -= amount;

        //Set the health bar's value to the current health. 
        healthSlider.value = currentHealth;

        //Play hurt sound effect
        playerAudio.Play ();

        //If the player has lost all it's health and the death flag hasn't been set
        if(currentHealth <= 0 && !isDead)
        {
            //then kill player
            Death();
        }
    }

    void Death ()
    {
        //Set the death flag so this function won't be recalled
        isDead = true;

        //Turn off any shooting effects

        //Tell the animator that the player is dead.
        anim.SetTrigger ("Die");

        //Set the audiosource to play the death clip and play it (this will stop hurt sound)
        playerAudio.clip = deathClip;
        playerAudio.Play ();

        //Turn off movement and shooting
        playerController.enabled = false;
    }
}
