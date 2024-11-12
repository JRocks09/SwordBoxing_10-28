using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float invincibilityTimer;
    [HideInInspector] public bool playerInvincible;
    [HideInInspector] public bool otherPlayerCanAttack;

    public PlayerController playerController;

    // Sound
    AudioManager audioManager;

    // Damage
    public float damage;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider collision)
    { 
        // Collision?
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            /* PUNCH:
                If the active attacker's fist collides with the other player, granted they aren't dodging */
            if ((playerController.P1Punch.activeInHierarchy || playerController.P2Punch.activeInHierarchy) 
                && !playerController.isP1Dodging && !playerController.isP2Dodging && !playerInvincible)
            {
                // Takes away health from the player based on the damage value
                playerController.flickering = true;
                playerInvincible = true;
                otherPlayerCanAttack = false;
                collision.gameObject.GetComponent<playerHealth>().health -= damage;
                Invoke(nameof(InvincibilityOver), invincibilityTimer);
                print(collision.name + " invincible");

                // Plays damage taken SFX [PUNCH] >> Change Later
                audioManager.PlaySFX(audioManager.damageTaken, 1);
            }

            /* SLICE:
                If the active attacker's sword collides with the other player, granted they aren't deflecting */
            if ((playerController.P1Slice.activeInHierarchy || playerController.P2Slice.activeInHierarchy)
                && !playerController.isP1Deflecting && !playerController.isP2Deflecting && !playerInvincible)
            {
                // Takes away health from the player based on the damage value
                playerController.flickering = true;
                playerInvincible = true;
                otherPlayerCanAttack = false;
                collision.gameObject.GetComponent<playerHealth>().health -= damage;
                Invoke(nameof(InvincibilityOver), invincibilityTimer);
                print(collision.name + " invincible");

                // Plays damage taken SFX [SLICE] >> Change Later
                audioManager.PlaySFX(audioManager.damageTaken, 1);
            }
        }
    }

    void InvincibilityOver()
    {
        playerInvincible = false;

        if (name == "P1PunchFist" || name == "P1SliceArc")
        {
            print("Player2 vulnerable");
        }
        if(name == "P2PunchFist" || name == "P2SliceArc")
        {
            print("Player1 vulnerable");
        }
    }

}