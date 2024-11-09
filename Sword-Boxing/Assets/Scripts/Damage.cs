using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float invincibilityTimer;
    private bool playerInvincible;

    // Sound
    AudioManager audioManager;


    // Damage
    public float damage;

    // Sound Initializing
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerInvincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    { 
        // If the active attacker fist collides with the other player
        if ((collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2")) && !playerInvincible)
        {
            // Takes away health from the player based on the damage value
            collision.gameObject.GetComponent<playerHealth>().health -= damage;
            Invoke(nameof(InvincibilityOver), invincibilityTimer);
            playerInvincible = true;
            print(collision.name + " invincible");

            // Plays damage taken SFX
            audioManager.PlaySFX(audioManager.damageTaken, 1);
        }

    }
    void InvincibilityOver()
    {
        playerInvincible = false;

        if(name == "P1PunchFist")
        {
            print("Player2 vulnerable");
        }
        if(name == "P2PunchFist")
        {
            print("Player1 vulernable");
        }
    }

}