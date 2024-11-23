using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
#pragma warning disable IDE0051 // Remove unused private members

    public GameObject player1Mesh;
    public GameObject player2Mesh;

    public GameObject P1Main;
    public GameObject P2Main;

    public GameObject P1Punch;
    public GameObject P2Punch;
    public GameObject P1PunchFake;
    public GameObject P2PunchFake;

    public GameObject P1Dodge;
    public GameObject P2Dodge;
    [HideInInspector] public bool isP1Dodging;
    [HideInInspector] public bool isP2Dodging;

    public GameObject P1Slice;
    public GameObject P2Slice;
    public GameObject P1SliceFake;
    public GameObject P2SliceFake;

    public GameObject P1Deflect;
    public GameObject P2Deflect;
    [HideInInspector] public bool isP1Deflecting;
    [HideInInspector] public bool isP2Deflecting;

    [HideInInspector] public bool P1flickering;
    [HideInInspector] public bool P2flickering;
    [HideInInspector] public bool P1WinFunction;
    [HideInInspector] public bool P2WinFunction;



    private bool P1Action;
    private bool P2Action;

    public Damage P1PunchDamage;
    public Damage P2PunchDamage;
    public Damage P1SliceDamage;
    public Damage P2SliceDamage;

    public playerHealth P1Health;
    public playerHealth P2Health;

    public Animator P1Animator;
    public Animator P2Animator;

    void Start()
    {
        P1PunchDamage.otherPlayerCanAttack = true;
        P2PunchDamage.otherPlayerCanAttack = true;
        P1SliceDamage.otherPlayerCanAttack = true;
        P2SliceDamage.otherPlayerCanAttack = true;

        P1WinFunction = true;
        P2WinFunction = true;
    }


    void Update()
    {
        // Variable Initialization
        var P1Pos = P1Main.transform.position;
        var P2Pos = P2Main.transform.position;

        // Quit Application
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // Restart Game on Finish
        if (P1Health.winState || P2Health.winState)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("BoxingRing");
            }
        }

        // Player Action Logic
        else
        {
            // ~ Player 1 Controls ~

            // Punch
            if (Input.GetKeyDown(KeyCode.E) && !P1Action)
            {
                StartCoroutine(P1PunchFunction());
            }

            IEnumerator P1PunchFunction()
            {
                P1Action = true;
                // print("p1 punch start");

                // Animation
                P1Animator.SetBool("IsPunching", true);

                yield return new WaitForSeconds(0.6f); // Time value is length from start of punch to impact

                if (!isP2Dodging)
                {
                    Invoke("Player1PunchEnd", 0.8f); // Time value is length from impact to end of punch

                    // Punch Successful (Not attacked by the other player before this punch's impact)
                    if (P2PunchDamage.otherPlayerCanAttack && !P1SliceDamage.playerInvincible && !P1PunchDamage.playerInvincible)
                    {
                        P2Action = true;
                        P1Punch.SetActive(true);
                        P2Animator.SetBool("Damaged", true);

                        yield return new WaitForSeconds(0.1f); // Time value is punch impact duration
                        P1Punch.SetActive(false);
                        P2Animator.SetBool("Damaged", false);

                        yield return new WaitForSeconds(0.7f);
                        P2Action = false;
                    }
                    else
                    {
                        P1PunchFake.SetActive(true); // "Fake" means that the punch visually looks the same, but doesn't work mechanically

                        yield return new WaitForSeconds(0.1f);
                        P1PunchFake.SetActive(false);
                    }
                }
                else if (isP2Dodging && !P2SliceDamage.playerInvincible && !P2PunchDamage.playerInvincible)
                {
                    // Punch was unsuccessful, player stunned
                    P1PunchFake.SetActive(true);
                    P2PunchDamage.otherPlayerCanAttack = true;

                    P1Animator.SetBool("IsStunned", true);

                    yield return new WaitForSeconds(0.1f);
                    P1PunchFake.SetActive(false);

                    yield return new WaitForSeconds(1.5f); // Time value is stunned period
                    P1Animator.SetBool("IsStunned", false);
                    Player1PunchEnd();
                }
                else // Edge Case: Player attacks other's defence while invincible. Does not stun attacking player.
                {
                    Invoke("Player1PunchEnd", 0.8f);
                    P1PunchFake.SetActive(true);

                    yield return new WaitForSeconds(0.1f);
                    P1PunchFake.SetActive(false);
                }
            }

            // Dodge
            if (Input.GetKeyDown(KeyCode.W) && !P1Action)
            {
                StartCoroutine(P1DodgeFunction());
            }

            IEnumerator P1DodgeFunction()
            {
                P1Action = true;
                // print("p1 dodge start");

                // Animation
                P1Animator.SetBool("IsDodging", true);

                yield return new WaitForSeconds(0.2f); // Time [before] player is in dodging state
                isP1Dodging = true;
                P1Dodge.SetActive(true);

                yield return new WaitForSeconds(1); // Time [when] player is in dodging state

                // End of Dodge
                isP1Dodging = false;
                P1Dodge.SetActive(false);
                Player1DodgeEnd();
            }

            // Slice
            if (Input.GetKeyDown(KeyCode.S) && !P1Action)
            {
                StartCoroutine(P1SliceFunction());
            }

            IEnumerator P1SliceFunction()
            {
                P1Action = true;
                // print("p1 slice start");

                // Animation
                P1Animator.SetBool("IsSlicing", true);

                yield return new WaitForSeconds(0.5f); // Time value is length from start of slice to impact

                if (!isP2Deflecting)
                {
                    Invoke("Player1SliceEnd", 0.8f); // Time value is length from impact to end of slice

                    // Slice Successful (Not attacked by the other player before this slice's impact)
                    if (P2SliceDamage.otherPlayerCanAttack && !P1SliceDamage.playerInvincible && !P1PunchDamage.playerInvincible)
                    {
                        P2Action = true;
                        P1Slice.SetActive(true);
                        P2Animator.SetBool("Damaged", true);

                        yield return new WaitForSeconds(0.1f); // Time value is slice impact duration
                        P1Slice.SetActive(false);
                        P2Animator.SetBool("Damaged", false);

                        yield return new WaitForSeconds(0.7f);
                        P2Action = false;
                    }
                    else
                    {
                        P1SliceFake.SetActive(true); // "Fake" means that the slice visually looks the same, but doesn't work mechanically

                        yield return new WaitForSeconds(0.1f);
                        P1SliceFake.SetActive(false);
                    }
                }
                else if (isP2Deflecting && !P2SliceDamage.playerInvincible && !P2PunchDamage.playerInvincible)
                {
                    // Slice was unsuccessful, player stunned
                    P1SliceFake.SetActive(true);
                    P2SliceDamage.otherPlayerCanAttack = true;

                    P1Animator.SetBool("IsStunned", true);

                    yield return new WaitForSeconds(0.1f);
                    P1SliceFake.SetActive(false);

                    yield return new WaitForSeconds(1.5f); // Time value is stunned period
                    P1Animator.SetBool("IsStunned", false);
                    Player1SliceEnd();
                }
                else // Edge Case: Player attacks other's defence while invincible. Does not stun attacking player.
                {
                    Invoke("Player1PunchEnd", 0.8f);
                    P1SliceFake.SetActive(true);

                    yield return new WaitForSeconds(0.1f);
                    P1SliceFake.SetActive(false);
                }
            }

            // Deflect
            if (Input.GetKeyDown(KeyCode.A) && !P1Action)
            {
                StartCoroutine(P1DeflectFunction());
            }

            IEnumerator P1DeflectFunction()
            {
                P1Action = true;
                // print("p1 deflect start");

                // Animation
                P1Animator.SetBool("IsDeflecting", true);
                P1Main.transform.position = new Vector3(P1Pos.x, (P1Pos.y + 0.4f), P1Pos.z);

                yield return new WaitForSeconds(0.2f); // Time [before] player is in deflecting state
                isP1Deflecting = true;
                P1Deflect.SetActive(true);

                yield return new WaitForSeconds(0.5f); // Time [when] player is in deflecting state

                // End of Deflect
                isP1Deflecting = false;
                P1Deflect.SetActive(false);
                Player1DeflectEnd();

                yield return new WaitForSeconds(0.15f);
                P1Main.transform.position = new Vector3(P1Pos.x, P1Pos.y, P1Pos.z);
            }

            // Damage Flicker (I-Frames)
            if (P1flickering && (P2SliceDamage.playerInvincible || P2PunchDamage.playerInvincible))
            {
                StartCoroutine(P1DamageFlicker());
                P1flickering = false;
            }

            IEnumerator P1DamageFlicker()
            {
                yield return new WaitForSeconds(1.3f);
                if(!P1Health.winState)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        player1Mesh.SetActive(false);
                        yield return new WaitForSeconds(0.1f);
                        player1Mesh.SetActive(true);
                        yield return new WaitForSeconds(0.1f);
                    }
                }
            }









            // --------------------------------------------------









            // ~ Player 2 Controls ~

            // Punch
            if (Input.GetKeyDown(KeyCode.I) && !P2Action)
            {
                StartCoroutine(P2PunchFunction());
            }

            IEnumerator P2PunchFunction()
            {
                P2Action = true;
                // print("p2 punch start");

                // Animation 
                P2Animator.SetBool("IsPunching", true);

                yield return new WaitForSeconds(0.6f); // Time value is length from start of punch to impact

                if (!isP1Dodging)
                {
                    Invoke("Player2PunchEnd", 0.8f); // Time value is length from impact to end of punch

                    // Punch Successful (Not attacked by the other player before this punch's impact)
                    if (P1PunchDamage.otherPlayerCanAttack && !P2SliceDamage.playerInvincible && !P2PunchDamage.playerInvincible)
                    {
                        P1Action = true;
                        P2Punch.SetActive(true);
                        P1Animator.SetBool("Damaged", true);

                        yield return new WaitForSeconds(0.1f); // Time value is punch impact duration
                        P2Punch.SetActive(false);
                        P1Animator.SetBool("Damaged", false);

                        yield return new WaitForSeconds(0.7f);
                        P1Action = false;
                    }
                    else
                    {
                        P2PunchFake.SetActive(true); // "Fake" means that the punch visually looks the same, but doesn't work mechanically

                        yield return new WaitForSeconds(0.1f);
                        P2PunchFake.SetActive(false);
                    }
                }
                else if (isP1Dodging && !P1SliceDamage.playerInvincible && !P1PunchDamage.playerInvincible)
                {
                    // Punch was unsuccessful, player stunned
                    P2PunchFake.SetActive(true);
                    P1PunchDamage.otherPlayerCanAttack = true;

                    P2Animator.SetBool("IsStunned", true);

                    yield return new WaitForSeconds(0.1f);
                    P2PunchFake.SetActive(false);

                    yield return new WaitForSeconds(1.5f); // Time value is stunned period
                    P2Animator.SetBool("IsStunned", false);
                    Player2PunchEnd();
                }
                else // Edge Case: Player attacks other's defence while invincible. Does not stun attacking player.
                {
                    Invoke("Player1PunchEnd", 0.8f);
                    P2PunchFake.SetActive(true);

                    yield return new WaitForSeconds(0.1f);
                    P2PunchFake.SetActive(false);
                }
            }

            // Dodge
            if (Input.GetKeyDown(KeyCode.O) && !P2Action)
            {
                StartCoroutine(P2DodgeFunction());
            }

            IEnumerator P2DodgeFunction()
            {
                P2Action = true;
                // print("p2 dodge start");

                // Animation
                P2Animator.SetBool("IsDodging", true);

                yield return new WaitForSeconds(0.2f); // Time [before] player is in dodging state
                isP2Dodging = true;
                P2Dodge.SetActive(true);

                yield return new WaitForSeconds(1); // Time [when] player is in dodging state

                // End of Dodge
                isP2Dodging = false;
                P2Dodge.SetActive(false);
                Player2DodgeEnd();
            }

            // Slice
            if (Input.GetKeyDown(KeyCode.K) && !P2Action)
            {
                StartCoroutine(P2SliceFunction());
            }

            IEnumerator P2SliceFunction()
            {
                P2Action = true;
                // print("p2 slice start");

                // Animation
                P2Animator.SetBool("IsSlicing", true);

                yield return new WaitForSeconds(0.5f); // Time value is length from start of slice to impact

                if (!isP1Deflecting)
                {
                    Invoke("Player2SliceEnd", 0.8f); // Time value is length from impact to end of slice

                    // Slice Successful (Not attacked by the other player before this slice's impact)
                    if (P1SliceDamage.otherPlayerCanAttack && !P2SliceDamage.playerInvincible && !P2PunchDamage.playerInvincible)
                    {
                        P1Action = true;
                        P2Slice.SetActive(true);
                        P1Animator.SetBool("Damaged", true);

                        yield return new WaitForSeconds(0.1f); // Time value is slice impact duration
                        P2Slice.SetActive(false);
                        P1Animator.SetBool("Damaged", false);

                        yield return new WaitForSeconds(0.7f);
                        P1Action = false;
                    }
                    else
                    {
                        P2SliceFake.SetActive(true); // "Fake" means that the slice visually looks the same, but doesn't work mechanically

                        yield return new WaitForSeconds(0.1f);
                        P2SliceFake.SetActive(false);
                    }
                }
                else if (isP1Deflecting && !P1SliceDamage.playerInvincible && !P1PunchDamage.playerInvincible)
                {
                    // Slice was unsuccessful, player stunned
                    P2SliceFake.SetActive(true);
                    P1SliceDamage.otherPlayerCanAttack = true;

                    P2Animator.SetBool("IsStunned", true);

                    yield return new WaitForSeconds(0.1f);
                    P2SliceFake.SetActive(false);

                    yield return new WaitForSeconds(1.5f); // Time value is stunned period
                    P2Animator.SetBool("IsStunned", false);
                    Player2SliceEnd();
                }
                else // Edge Case: Player attacks other's defence while invincible. Does not stun attacking player.
                {
                    Invoke("Player1PunchEnd", 0.8f);
                    P2SliceFake.SetActive(true);

                    yield return new WaitForSeconds(0.1f);
                    P2SliceFake.SetActive(false);
                }
            }

            // Deflect
            if (Input.GetKeyDown(KeyCode.L) && !P2Action)
            {
                StartCoroutine(P2DeflectFunction());
            }

            IEnumerator P2DeflectFunction()
            {
                P2Action = true;
                // print("p2 deflect start");

                // Animation
                P2Animator.SetBool("IsDeflecting", true);
                P2Main.transform.position = new Vector3(P2Pos.x, (P2Pos.y + 0.4f), P2Pos.z);

                yield return new WaitForSeconds(0.2f); // Time [before] player is in deflecting state
                isP2Deflecting = true;
                P2Deflect.SetActive(true);

                yield return new WaitForSeconds(0.5f); // Time [when] player is in deflecting state

                // End of Deflect
                isP2Deflecting = false;
                P2Deflect.SetActive(false);
                Player2DeflectEnd();

                yield return new WaitForSeconds(0.15f);
                P2Main.transform.position = new Vector3(P2Pos.x, P2Pos.y, P2Pos.z);
            }

            // Damage Flicker (I-Frames)
            if (P2flickering && (P1SliceDamage.playerInvincible || P1PunchDamage.playerInvincible))
            {
                StartCoroutine(P2DamageFlicker());
                P2flickering = false;
            }

            IEnumerator P2DamageFlicker()
            {
                yield return new WaitForSeconds(1.3f);

                if (!P2Health.winState)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        player2Mesh.SetActive(false);
                        yield return new WaitForSeconds(0.1f);
                        player2Mesh.SetActive(true);
                        yield return new WaitForSeconds(0.1f);
                    }
                }
            }
        }
        

        // P1 Defeated
        if (P1Health.winState && P1WinFunction)
        {
            StartCoroutine(Player1Defeated());
            P1WinFunction = false;
        }

        IEnumerator Player1Defeated()
        {
            yield return new WaitForSeconds(0.5f);

            P1Main.transform.position = new Vector3(P1Pos.x, (P1Pos.y + 0.4f), P1Pos.z);
            P2Main.transform.position = new Vector3(P2Pos.x, (P2Pos.y + 0.4f), P2Pos.z);
            P1Animator.SetBool("Defeated", true);
            P2Animator.SetBool("GameWon", true);

            yield return new WaitForSeconds(0.01f);

            P1Animator.SetBool("Defeated", false);
            P2Animator.SetBool("GameWon", false);

            // Fixes for Character Animation Inconcistency
            if (P1Main.name == "Brute")
            {
                yield return new WaitForSeconds(2.25f);
                P1Main.transform.position = new Vector3(P1Pos.x, P1Pos.y, P1Pos.z);
            }
            else if (P1Main.name == "Ninja")
            {
                yield return new WaitForSeconds(2.25f);
                P1Main.transform.position = new Vector3(P1Pos.x, P1Pos.y + 0.3f, P1Pos.z);
            }
            else if (P1Main.name == "Kachujin")
            {
                yield return new WaitForSeconds(2.25f);
                P1Main.transform.position = new Vector3(P1Pos.x, P1Pos.y + 0.1f, P1Pos.z);
            }
        }

        // P2 Defeated
        if (P2Health.winState && P2WinFunction)
        {
            StartCoroutine(Player2Defeated());
            P2WinFunction = false;
        }

        IEnumerator Player2Defeated()
        {
            yield return new WaitForSeconds(0.5f);

            P1Main.transform.position = new Vector3(P1Pos.x, (P1Pos.y + 0.4f), P1Pos.z);
            P2Main.transform.position = new Vector3(P2Pos.x, (P2Pos.y + 0.4f), P2Pos.z);
            P2Animator.SetBool("Defeated", true);
            P1Animator.SetBool("GameWon", true);

            yield return new WaitForSeconds(0.01f);

            P2Animator.SetBool("Defeated", false);
            P1Animator.SetBool("GameWon", false);

            // Fixes for Character Animation Inconcistency
            if (P2Main.name == "Brute")
            {
                yield return new WaitForSeconds(2.25f);
                P2Main.transform.position = new Vector3(P2Pos.x, P2Pos.y, P2Pos.z);
            }
            else if(P2Main.name == "Ninja")
            {
                yield return new WaitForSeconds(2.25f);
                P2Main.transform.position = new Vector3(P2Pos.x, P2Pos.y + 0.3f, P2Pos.z);
            }
            else if (P2Main.name == "Kachujin")
            {
                yield return new WaitForSeconds(2.25f);
                P2Main.transform.position = new Vector3(P2Pos.x, P2Pos.y + 0.1f, P2Pos.z);
            }
        }
    }


    // Player 1 Void Functions
    void Player1PunchEnd()
    {
        P1Action = false;
        P1Animator.SetBool("IsPunching", false);

        // print("p1 punch end");
        player1Mesh.SetActive(true);
        P2PunchDamage.otherPlayerCanAttack = true;
        P1PunchDamage.otherPlayerCanAttack = true;
    }
    void Player1DodgeEnd()
    {
        P1Action = false;
        P1Animator.SetBool("IsDodging", false);

        // print("p1 dodge end");
    }
    void Player1SliceEnd()
    {
        P1Action = false;
        P1Animator.SetBool("IsSlicing", false);

        // print("p1 slice end");
        player1Mesh.SetActive(true);
        P2SliceDamage.otherPlayerCanAttack = true;
        P1SliceDamage.otherPlayerCanAttack = true;
    }
    void Player1DeflectEnd()
    {
        P1Action = false;
        P1Animator.SetBool("IsDeflecting", false);

        // print("p1 deflect end");
    }


    // Player 2 Void Functions
    void Player2PunchEnd()
    {
        P2Action = false;
        P2Animator.SetBool("IsPunching", false);

        // print("p2 punch end");
        player2Mesh.SetActive(true);
        P1PunchDamage.otherPlayerCanAttack = true;
        P2PunchDamage.otherPlayerCanAttack = true;
    }
    void Player2DodgeEnd()
    {
        P2Action = false;
        P2Animator.SetBool("IsDodging", false);

        // print("p2 dodge end");
    }
    void Player2SliceEnd()
    {
        P2Action = false;
        P2Animator.SetBool("IsSlicing", false);

        // print("p2 slice end");
        player2Mesh.SetActive(true);
        P1SliceDamage.otherPlayerCanAttack = true;
        P2SliceDamage.otherPlayerCanAttack = true;
    }
    void Player2DeflectEnd()
    {
        P2Action = false;
        P2Animator.SetBool("IsDeflecting", false);

        // print("p2 deflect end");
    }
}