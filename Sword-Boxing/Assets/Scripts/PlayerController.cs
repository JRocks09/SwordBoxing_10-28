using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private bool P1Action;
    private bool P2Action;

    // public Animator P1Animator;
    // public Animator P2Animator;

    void Start()
    {
        // P1Animator = player1.GetComponent<Animator>();
        // P2Animator = player2.GetComponent<Animator>();
    }

    
    void Update()
    {
        /* 
        ~ Player 1 Controls ~
        
        Punch */
        if(Input.GetKeyDown(KeyCode.W) && !P1Action)
        {
            P1Action = true;
            print("p1 punch start");

            /* Animation will be triggered here
            P1Animator.SetBool("IsPunching", true); */

            Invoke("Player1PunchEnd", 0.7f); /* Time value is length of animation */
        }

        // Dodge
        if(Input.GetKeyDown(KeyCode.Q) && !P1Action)
        {
            P1Action = true;
            print("p1 dodge start");

            /* Animation will be triggered here
            P1Animator.SetBool("IsDodging", true); */

            Invoke("Player1DodgeEnd", 1.0f); /* Time value is length of animation */
        }

        // Slice
        if (Input.GetKeyDown(KeyCode.S) && !P1Action)
        {
            P1Action = true;
            print("p1 slice start");

            /* Animation will be triggered here 
            P1Animator.SetBool("IsSlicing", true); */

            Invoke("Player1SliceEnd", 0.5f); /* Time value is length of animation */
        }

        // Deflect
        if (Input.GetKeyDown(KeyCode.A) && !P1Action)
        {
            P1Action = true;
            print("p1 deflect start");

            /* Animation will be triggered here
            P1Animator.SetBool("IsDeflecting", true); */

            Invoke("Player1DeflectEnd", 1.0f); /* Time value is length of animation */
        }

        /* 
        ~ Player 2 Controls ~
        
        Punch */
        if (Input.GetKeyDown(KeyCode.O) && !P2Action)
        {
            P2Action = true;
            print("p2 punch start");

            /* Animation will be triggered here
            P2Animator.SetBool("IsPunching", true); */

            Invoke("Player2PunchEnd", 0.7f); /* Time value is length of animation */
        }

        // Dodge
        if (Input.GetKeyDown(KeyCode.P) && !P2Action)
        {
            P2Action = true;
            print("p2 dodge start");

            /* Animation will be triggered here
            P2Animator.SetBool("IsDodging", true); */

            Invoke("Player2DodgeEnd", 1.0f); /* Time value is length of animation */
        }

        // Slice
        if (Input.GetKeyDown(KeyCode.K) && !P2Action)
        {
            P2Action = true;
            print("p2 slice start");

            /* Animation will be triggered here 
            P2Animator.SetBool("IsSlicing", true); */

            Invoke("Player2SliceEnd", 0.5f); /* Time value is length of animation */
        }


        // Deflect
        if (Input.GetKeyDown(KeyCode.L) && !P2Action)
        {
            P2Action = true;
            print("p2 deflect start");

            /* Animation will be triggered here
            P2Animator.SetBool("IsDeflecting", true); */

            Invoke("Player2DeflectEnd", 1.0f); /* Time value is length of animation */
        }

    }

    // Player 1 Void Functions
    void Player1PunchEnd()
    {
        P1Action = false;
        // P1Animator.SetBool("IsPunching", false);
        print("p1 punch end");
    }
    void Player1DodgeEnd()
    {
        P1Action = false;
        // P1Animator.SetBool("IsDodging", false);
        print("p1 dodge end");
    }
    void Player1SliceEnd()
    {
        P1Action = false;
        // P1Animator.SetBool("IsSlicing", false);
        print("p1 slice end");
    }
    void Player1DeflectEnd()
    {
        P1Action = false;
        // P1Animator.SetBool("IsDeflecting", false);
        print("p1 deflect end");
    }


    // Player 2 Void Functions
    void Player2PunchEnd()
    {
        P2Action = false;
        // P2Animator.SetBool("IsPunching", false);
        print("p2 punch end");
    }
    void Player2DodgeEnd()
    {
        P2Action = false;
        // P2Animator.SetBool("IsDodging", false);
        print("p2 dodge end");
    }
    void Player2SliceEnd()
    {
        P2Action = false;
        // P2Animator.SetBool("IsSlicing", false);
        print("p2 slice end");
    }
    void Player2DeflectEnd()
    {
        P2Action = false;
        // P2Animator.SetBool("IsDeflecting", false);
        print("p2 deflect end");
    }
}
