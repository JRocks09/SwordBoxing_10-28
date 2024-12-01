using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
#pragma warning disable IDE0051 // Remove unused private members

    [SerializeField] TextMeshProUGUI StartText;
    public GameObject StartTextObject;
    public GameObject buttons;
    public GameObject hideInitilizationSprite;

    public GameObject player1Mesh;
    public GameObject player2Mesh;
    public GameObject player1SwordMesh;
    public GameObject player2SwordMesh;
    public GameObject player1GloveMesh;
    public GameObject player2GloveMesh;

    public GameObject P1Main;
    public GameObject P2Main;

    public GameObject P1StunAnim;
    public GameObject P2StunAnim;

    public GameObject P1Punch;
    public GameObject P2Punch;

    public GameObject P1Dodge;
    public GameObject P2Dodge;
    [HideInInspector] public bool isP1Dodging;
    [HideInInspector] public bool isP2Dodging;

    public GameObject P1Slice;
    public GameObject P2Slice;

    public GameObject P1Deflect;
    public GameObject P2Deflect;
    [HideInInspector] public bool isP1Deflecting;
    [HideInInspector] public bool isP2Deflecting;

    [HideInInspector] public bool P1flickering;
    [HideInInspector] public bool P2flickering;
    [HideInInspector] public bool P1WinFunction;
    [HideInInspector] public bool P2WinFunction;

    SkinnedMeshRenderer P1Emission;
    SkinnedMeshRenderer P2Emission;

    public GameObject BruteMeshPart1;
    public GameObject BruteMeshPart2;
    public GameObject BruteMeshPart3;
    public GameObject BruteMeshPart4;
    public GameObject BruteMeshPart5;
    public GameObject BruteMeshPart6;
    public GameObject BruteMeshPart7;
    public GameObject BruteMeshPart8;

    SkinnedMeshRenderer BruteEmission1;
    SkinnedMeshRenderer BruteEmission2;
    SkinnedMeshRenderer BruteEmission3;
    SkinnedMeshRenderer BruteEmission4;
    SkinnedMeshRenderer BruteEmission5;
    SkinnedMeshRenderer BruteEmission6;
    SkinnedMeshRenderer BruteEmission7;
    SkinnedMeshRenderer BruteEmission8;

    private bool P1Action;
    private bool P2Action;

    private bool gameStarted2;
    private bool gameStarted;

    public GameObject P1Animator;
    public GameObject P2Animator;

    public Damage P1PunchDamage;
    public Damage P2PunchDamage;
    public Damage P1SliceDamage;
    public Damage P2SliceDamage;

    public playerHealth P1Health;
    public playerHealth P2Health;
    public LockerController lockerController;

    private AudioManager audioManager;

    void Start()
    {
        gameStarted = false;
        buttons.SetActive(false);
        hideInitilizationSprite.SetActive(true);

        // Initialization
        StartCoroutine(Initialization());
        IEnumerator Initialization()
        {
            yield return new WaitForSeconds(0.01f);

            // Player 1 Settings Initialization
            if (lockerController.P1CS == 0) // Brute/Rex
            {
                GameObject.Find("Wrestler (P1)").SetActive(false);
                GameObject.Find("Ninja (P1)").SetActive(false);
                GameObject.Find("Kachujin (P1)").SetActive(false);

                P1Main = GameObject.Find("Brute (P1)");
                player1Mesh = GameObject.Find("BruteMesh (P1)");
                player1SwordMesh = GameObject.Find("Red Sword (B)");
                player1GloveMesh = GameObject.Find("Red Glove (B)");
                P1Animator = GameObject.Find("Brute (P1)");

                BruteMeshPart1 = GameObject.Find("MaleBruteA_Body1");
                BruteMeshPart2 = GameObject.Find("MaleBruteA_Bottoms1");
                BruteMeshPart3 = GameObject.Find("MaleBruteA_Earrings1");
                BruteMeshPart4 = GameObject.Find("MaleBruteA_Eyelashes1");
                BruteMeshPart5 = GameObject.Find("MaleBruteA_Eyes1");
                BruteMeshPart6 = GameObject.Find("MaleBruteA_Hair1");
                BruteMeshPart7 = GameObject.Find("MaleBruteA_Moustaches1");
                BruteMeshPart8 = GameObject.Find("MaleBruteA_Shoes1");
}
            if (lockerController.P1CS == 1) // Kachjin/Crimson
            {
                GameObject.Find("Wrestler (P1)").SetActive(false);
                GameObject.Find("Ninja (P1)").SetActive(false);
                GameObject.Find("Brute (P1)").SetActive(false);

                P1Main = GameObject.Find("Kachujin (P1)");
                player1Mesh = GameObject.Find("KachujinMesh (P1)");
                player1SwordMesh = GameObject.Find("Red Sword (K)");
                player1GloveMesh = GameObject.Find("Red Glove (K)");
                P1Animator = GameObject.Find("Kachujin (P1)");
            }
            if (lockerController.P1CS == 2) // Wrestler/El Devil
            {
                GameObject.Find("Brute (P1)").SetActive(false);
                GameObject.Find("Ninja (P1)").SetActive(false);
                GameObject.Find("Kachujin (P1)").SetActive(false);

                P1Main = GameObject.Find("Wrestler (P1)");
                player1Mesh = GameObject.Find("WrestlerMesh (P1)");
                player1SwordMesh = GameObject.Find("Red Sword (W)");
                player1GloveMesh = GameObject.Find("Red Glove (W)");
                P1Animator = GameObject.Find("Wrestler (P1)");
            }
            if (lockerController.P1CS == 3) // Ninja/Jin
            {
                GameObject.Find("Wrestler (P1)").SetActive(false);
                GameObject.Find("Brute (P1)").SetActive(false);
                GameObject.Find("Kachujin (P1)").SetActive(false);

                P1Main = GameObject.Find("Ninja (P1)");
                player1Mesh = GameObject.Find("NinjaMesh (P1)");
                player1SwordMesh = GameObject.Find("Red Sword (N)");
                player1GloveMesh = GameObject.Find("Red Glove (N)");
                P1Animator = GameObject.Find("Ninja (P1)");
            }

            // Player 2 Settings Initialization
            if (lockerController.P2CS == 0) // Brute/Rex
            {
                GameObject.Find("Wrestler (P2)").SetActive(false);
                GameObject.Find("Ninja (P2)").SetActive(false);
                GameObject.Find("Kachujin (P2)").SetActive(false);

                P2Main = GameObject.Find("Brute (P2)");
                player2Mesh = GameObject.Find("BruteMesh (P2)");
                player2SwordMesh = GameObject.Find("Blue Sword (B)");
                player2GloveMesh = GameObject.Find("Blue Glove (B)");
                P2Animator = GameObject.Find("Brute (P2)");

                BruteMeshPart1 = GameObject.Find("MaleBruteA_Body2");
                BruteMeshPart2 = GameObject.Find("MaleBruteA_Bottoms2");
                BruteMeshPart3 = GameObject.Find("MaleBruteA_Earrings2");
                BruteMeshPart4 = GameObject.Find("MaleBruteA_Eyelashes2");
                BruteMeshPart5 = GameObject.Find("MaleBruteA_Eyes2");
                BruteMeshPart6 = GameObject.Find("MaleBruteA_Hair2");
                BruteMeshPart7 = GameObject.Find("MaleBruteA_Moustaches2");
                BruteMeshPart8 = GameObject.Find("MaleBruteA_Shoes2");
            }
            if (lockerController.P2CS == 1) // Kachjin/Crimson
            {
                GameObject.Find("Wrestler (P2)").SetActive(false);
                GameObject.Find("Ninja (P2)").SetActive(false);
                GameObject.Find("Brute (P2)").SetActive(false);

                P2Main = GameObject.Find("Kachujin (P2)");
                player2Mesh = GameObject.Find("KachujinMesh (P2)");
                player2SwordMesh = GameObject.Find("Blue Sword (K)");
                player2GloveMesh = GameObject.Find("Blue Glove (K)");
                P2Animator = GameObject.Find("Kachujin (P2)");
            }
            if (lockerController.P2CS == 2) // Wrestler/El Devil
            {
                GameObject.Find("Brute (P2)").SetActive(false);
                GameObject.Find("Ninja (P2)").SetActive(false);
                GameObject.Find("Kachujin (P2)").SetActive(false);

                P2Main = GameObject.Find("Wrestler (P2)");
                player2Mesh = GameObject.Find("WrestlerMesh (P2)");
                player2SwordMesh = GameObject.Find("Blue Sword (W)");
                player2GloveMesh = GameObject.Find("Blue Glove (W)");
                P2Animator = GameObject.Find("Wrestler (P2)");
            }
            if (lockerController.P2CS == 3) // Ninja/Jin
            {
                GameObject.Find("Wrestler (P2)").SetActive(false);
                GameObject.Find("Brute (P2)").SetActive(false);
                GameObject.Find("Kachujin (P2)").SetActive(false);

                P2Main = GameObject.Find("Ninja (P2)");
                player2Mesh = GameObject.Find("NinjaMesh (P2)");
                player2SwordMesh = GameObject.Find("Blue Sword (N)");
                player2GloveMesh = GameObject.Find("Blue Glove (N)");
                P2Animator = GameObject.Find("Ninja (P2)");
            }

            yield return new WaitForSeconds(0.01f);
            gameStarted = true;

            if (gameStarted)
            {
                P1PunchDamage.otherPlayerCanAttack = true;
                P2PunchDamage.otherPlayerCanAttack = true;
                P1SliceDamage.otherPlayerCanAttack = true;
                P2SliceDamage.otherPlayerCanAttack = true;

                P1WinFunction = true;
                P2WinFunction = true;
                gameStarted2 = true;

                StartTextObject.SetActive(false);

                P1Emission = player1Mesh.GetComponent<SkinnedMeshRenderer>();
                P2Emission = player2Mesh.GetComponent<SkinnedMeshRenderer>();
                BruteEmission1 = BruteMeshPart1.GetComponent<SkinnedMeshRenderer>();
                BruteEmission2 = BruteMeshPart2.GetComponent<SkinnedMeshRenderer>();
                BruteEmission3 = BruteMeshPart3.GetComponent<SkinnedMeshRenderer>();
                BruteEmission4 = BruteMeshPart4.GetComponent<SkinnedMeshRenderer>();
                BruteEmission5 = BruteMeshPart5.GetComponent<SkinnedMeshRenderer>();
                BruteEmission6 = BruteMeshPart6.GetComponent<SkinnedMeshRenderer>();
                BruteEmission7 = BruteMeshPart7.GetComponent<SkinnedMeshRenderer>();
                BruteEmission8 = BruteMeshPart8.GetComponent<SkinnedMeshRenderer>();

                hideInitilizationSprite.SetActive(false);

                if (P1Main.name == "Kachujin (P1)")
                {
                    P1Emission.materials[0].DisableKeyword("_EMISSION");
                    P1Emission.materials[1].DisableKeyword("_EMISSION");
                }
                else if (P1Main.name == "Brute (P1)")
                {
                    BruteEmission1.material.DisableKeyword("_EMISSION");
                    BruteEmission2.material.DisableKeyword("_EMISSION");
                    BruteEmission3.material.DisableKeyword("_EMISSION");
                    BruteEmission4.material.DisableKeyword("_EMISSION");
                    BruteEmission5.material.DisableKeyword("_EMISSION");
                    BruteEmission6.material.DisableKeyword("_EMISSION");
                    BruteEmission7.material.DisableKeyword("_EMISSION");
                    BruteEmission8.material.DisableKeyword("_EMISSION");
                }
                else if (P1Main.name is "Ninja (P1)" or "Wrestler (P1)")
                {
                    P1Emission.material.DisableKeyword("_EMISSION");
                }

                if (P2Main.name == "Kachujin (P2)")
                {
                    P2Emission.materials[0].DisableKeyword("_EMISSION");
                    P2Emission.materials[1].DisableKeyword("_EMISSION");
                }
                else if (P2Main.name == "Brute (P2)")
                {
                    BruteEmission1.material.DisableKeyword("_EMISSION");
                    BruteEmission2.material.DisableKeyword("_EMISSION");
                    BruteEmission3.material.DisableKeyword("_EMISSION");
                    BruteEmission4.material.DisableKeyword("_EMISSION");
                    BruteEmission5.material.DisableKeyword("_EMISSION");
                    BruteEmission6.material.DisableKeyword("_EMISSION");
                    BruteEmission7.material.DisableKeyword("_EMISSION");
                    BruteEmission8.material.DisableKeyword("_EMISSION");
                }
                else if (P2Main.name is "Ninja (P2)" or "Wrestler (P2)")
                {
                    P2Emission.material.DisableKeyword("_EMISSION");
                }
            }
        }
    }
      private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Update()
    {
        if (gameStarted)
        {
            // Variable Initialization
            Animator p1Animator = P1Animator.GetComponent<Animator>();
            Animator p2Animator = P2Animator.GetComponent<Animator>();
            var P1Pos = P1Main.transform.position;
            var P2Pos = P2Main.transform.position;

            StartCoroutine(GameStart());

            IEnumerator GameStart()
            {
                if (gameStarted2)
                {
                    gameStarted2 = false;

                    yield return new WaitForSeconds(2.5f);
                    StartText.text = "Ready?";
                    audioManager.PlaySFX(audioManager.readySound, 1);
                    StartTextObject.SetActive(true);

                    yield return new WaitForSeconds(1.5f);
                    StartText.text = "Go!";
                    audioManager.PlaySFX(audioManager.goSound, 1);
                }

                // Player Action Logic
                if (!(P1Health.winState || P2Health.winState))
                {
                    yield return new WaitForSeconds(4.2f);
                    audioManager.PlaySFX(audioManager.boxingBGM, 0.03f); // Keep this volume for the BGM


                    // ~ Player 1 Controls ~

                    // Punch
                    if (Input.GetKeyDown(KeyCode.W) && !P1Action)
                    {
                        StartCoroutine(P1PunchFunction());
                    }

                    IEnumerator P1PunchFunction()
                    {
                        P1Action = true;
                        // print("p1 punch start");

                        // Animation
                        p1Animator.SetBool("IsPunching", true);

                        yield return new WaitForSeconds(0.6f); // Time value is length from start of punch to impact

                        if (!isP2Dodging && !(P1Health.winState || P2Health.winState))
                        {
                            Invoke("Player1PunchEnd", 0.8f); // Time value is length from impact to end of punch

                            // Punch Successful (Not attacked by the other player before this punch's impact)
                            if (P2PunchDamage.otherPlayerCanAttack && !P1SliceDamage.playerInvincible && !P1PunchDamage.playerInvincible)
                            {
                                P2StunAnim.SetActive(false);
                                yield return new WaitForSeconds(0.01f);
                                P2Action = true;
                                P1Punch.SetActive(true);
                                p2Animator.SetBool("Damaged", true);
                                audioManager.PlaySFX(audioManager.punchHit, 0.5f);

                                yield return new WaitForSeconds(0.1f); // Time value is punch impact duration
                                P1Punch.SetActive(false);
                                p2Animator.SetBool("Damaged", false);

                                yield return new WaitForSeconds(1.4f);
                                P2Action = false;
                            }
                        }
                        else if (isP2Dodging && !P2SliceDamage.playerInvincible && !P2PunchDamage.playerInvincible)
                        {
                            // Punch was unsuccessful, player stunned
                            P1StunAnim.SetActive(true);
                            P2PunchDamage.otherPlayerCanAttack = true;

                            p1Animator.SetBool("IsStunned", true);
                            audioManager.PlaySFX(audioManager.blockSound, 1);
                            audioManager.PlaySFX(audioManager.stunSound, 1);

                            yield return new WaitForSeconds(1.6f); // Time value is stunned period
                            P1StunAnim.SetActive(false);
                            p1Animator.SetBool("IsStunned", false);
                            Player1PunchEnd();
                        }
                        else // Edge Case: Player attacks other's defence while invincible. Does not stun attacking player.
                        {
                            Invoke("Player1PunchEnd", 0.8f);
                        }
                    }

                    // Dodge
                    if (Input.GetKeyDown(KeyCode.Q) && !P1Action)
                    {
                        StartCoroutine(P1DodgeFunction());
                    }

                    IEnumerator P1DodgeFunction()
                    {
                        P1Action = true;
                        // print("p1 dodge start");

                        // Animation
                        p1Animator.SetBool("IsDodging", true);

                        yield return new WaitForSeconds(0.2f); // Time [before] player is in dodging state

                        // Color Change (Yellow Emission)
                        if (P1Main.name == "Kachujin (P1)")
                        {
                            P1Emission.materials[0].EnableKeyword("_EMISSION");
                            P1Emission.materials[1].EnableKeyword("_EMISSION");
                            P1Emission.materials[0].globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            P1Emission.materials[1].globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                        }
                        else if (P1Main.name == "Brute (P1)")
                        {
                            BruteEmission1.material.EnableKeyword("_EMISSION");
                            BruteEmission2.material.EnableKeyword("_EMISSION");
                            BruteEmission3.material.EnableKeyword("_EMISSION");
                            BruteEmission4.material.EnableKeyword("_EMISSION");
                            BruteEmission5.material.EnableKeyword("_EMISSION");
                            BruteEmission6.material.EnableKeyword("_EMISSION");
                            BruteEmission7.material.EnableKeyword("_EMISSION");
                            BruteEmission8.material.EnableKeyword("_EMISSION");
                            BruteEmission1.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission2.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission3.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission4.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission5.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission6.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission7.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission8.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                        }
                        else if (P1Main.name is "Ninja (P1)" or "Wrestler (P1)")
                        {
                            P1Emission.material.EnableKeyword("_EMISSION");
                            P1Emission.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                        }

                        isP1Dodging = true;
                        P1Dodge.SetActive(true);
                        audioManager.PlaySFX(audioManager.dodgeSound, 1.5f);

                        yield return new WaitForSeconds(0.7f); // Time [when] player is in dodging state

                        // End of Dodge
                        if (P1Main.name == "Kachujin (P1)")
                        {
                            P1Emission.materials[0].globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            P1Emission.materials[1].globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            P1Emission.materials[0].DisableKeyword("_EMISSION");
                            P1Emission.materials[1].DisableKeyword("_EMISSION");
                        }
                        else if (P1Main.name == "Brute (P1)")
                        {
                            BruteEmission1.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission2.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission3.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission4.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission5.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission6.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission7.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission8.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission1.material.DisableKeyword("_EMISSION");
                            BruteEmission2.material.DisableKeyword("_EMISSION");
                            BruteEmission3.material.DisableKeyword("_EMISSION");
                            BruteEmission4.material.DisableKeyword("_EMISSION");
                            BruteEmission5.material.DisableKeyword("_EMISSION");
                            BruteEmission6.material.DisableKeyword("_EMISSION");
                            BruteEmission7.material.DisableKeyword("_EMISSION");
                            BruteEmission8.material.DisableKeyword("_EMISSION");
                        }
                        else if (P1Main.name is "Ninja (P1)" or "Wrestler (P1)")
                        {
                            P1Emission.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            P1Emission.material.DisableKeyword("_EMISSION");
                        }

                        yield return new WaitForSeconds(0.2f);

                        isP1Dodging = false;
                        P1Dodge.SetActive(false);
                        Player1DodgeEnd();

                        yield return new WaitForSeconds(0.2f);
                        P1Action = false;
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
                        p1Animator.SetBool("IsSlicing", true);

                        yield return new WaitForSeconds(0.5f); // Time value is length from start of slice to impact

                        if (!isP2Deflecting && !(P1Health.winState || P2Health.winState))
                        {
                            Invoke("Player1SliceEnd", 0.8f); // Time value is length from impact to end of slice

                            // Slice Successful (Not attacked by the other player before this slice's impact)
                            if (P2SliceDamage.otherPlayerCanAttack && !P1SliceDamage.playerInvincible && !P1PunchDamage.playerInvincible)
                            {
                                P2StunAnim.SetActive(false);
                                yield return new WaitForSeconds(0.01f);
                                P2Action = true;
                                P1Slice.SetActive(true);
                                p2Animator.SetBool("Damaged", true);
                                audioManager.PlaySFX(audioManager.swordHit, 1);

                                yield return new WaitForSeconds(0.1f); // Time value is slice impact duration
                                P1Slice.SetActive(false);
                                p2Animator.SetBool("Damaged", false);

                                yield return new WaitForSeconds(1.4f);
                                P2Action = false;
                            }
                        }
                        else if (isP2Deflecting && !P2SliceDamage.playerInvincible && !P2PunchDamage.playerInvincible)
                        {
                            // Slice was unsuccessful, player stunned
                            P1StunAnim.SetActive(true);
                            P2SliceDamage.otherPlayerCanAttack = true;

                            p1Animator.SetBool("IsStunned", true);
                            audioManager.PlaySFX(audioManager.swordClash, 1);
                            yield return new WaitForSeconds(0.01f);
                            audioManager.PlaySFX(audioManager.stunSound, 1);

                            yield return new WaitForSeconds(1.6f); // Time value is stunned period
                            P1StunAnim.SetActive(false);
                            p1Animator.SetBool("IsStunned", false);
                            Player1SliceEnd();
                        }
                        else // Edge Case: Player attacks other's defence while invincible. Does not stun attacking player.
                        {
                            Invoke("Player1SliceEnd", 0.8f);
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
                        p1Animator.SetBool("IsDeflecting", true);

                        yield return new WaitForSeconds(0.2f); // Time [before] player is in deflecting state

                        // Color Change (Yellow Emission)
                        if (P1Main.name == "Kachujin (P1)")
                        {
                            P1Emission.materials[0].EnableKeyword("_EMISSION");
                            P1Emission.materials[1].EnableKeyword("_EMISSION");
                            P1Emission.materials[0].globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            P1Emission.materials[1].globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                        }
                        else if (P1Main.name == "Brute (P1)")
                        {
                            BruteEmission1.material.EnableKeyword("_EMISSION");
                            BruteEmission2.material.EnableKeyword("_EMISSION");
                            BruteEmission3.material.EnableKeyword("_EMISSION");
                            BruteEmission4.material.EnableKeyword("_EMISSION");
                            BruteEmission5.material.EnableKeyword("_EMISSION");
                            BruteEmission6.material.EnableKeyword("_EMISSION");
                            BruteEmission7.material.EnableKeyword("_EMISSION");
                            BruteEmission8.material.EnableKeyword("_EMISSION");
                            BruteEmission1.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission2.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission3.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission4.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission5.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission6.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission7.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission8.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                        }
                        else if (P1Main.name is "Ninja (P1)" or "Wrestler (P1)")
                        {
                            P1Emission.material.EnableKeyword("_EMISSION");
                            P1Emission.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                        }

                        isP1Deflecting = true;
                        P1Deflect.SetActive(true);
                        audioManager.PlaySFX(audioManager.deflectSound, 1);

                        yield return new WaitForSeconds(0.65f); // Time [when] player is in deflecting state

                        // End of Deflect
                        if (P1Main.name == "Kachujin (P1)")
                        {
                            P1Emission.materials[0].globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            P1Emission.materials[1].globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            P1Emission.materials[0].DisableKeyword("_EMISSION");
                            P1Emission.materials[1].DisableKeyword("_EMISSION");
                        }
                        else if (P1Main.name == "Brute (P1)")
                        {
                            BruteEmission1.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission2.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission3.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission4.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission5.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission6.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission7.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission8.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission1.material.DisableKeyword("_EMISSION");
                            BruteEmission2.material.DisableKeyword("_EMISSION");
                            BruteEmission3.material.DisableKeyword("_EMISSION");
                            BruteEmission4.material.DisableKeyword("_EMISSION");
                            BruteEmission5.material.DisableKeyword("_EMISSION");
                            BruteEmission6.material.DisableKeyword("_EMISSION");
                            BruteEmission7.material.DisableKeyword("_EMISSION");
                            BruteEmission8.material.DisableKeyword("_EMISSION");
                        }
                        else if (P1Main.name is "Ninja (P1)" or "Wrestler (P1)")
                        {
                            P1Emission.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            P1Emission.material.DisableKeyword("_EMISSION");
                        }

                        isP1Deflecting = false;
                        P1Deflect.SetActive(false);
                        Player1DeflectEnd();

                        yield return new WaitForSeconds(0.2f);
                        P1Action = false;
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
                        if (!P1Health.winState)
                        {
                            for (int i = 0; i < 7; i++)
                            {
                                player1Mesh.SetActive(false);
                                player1SwordMesh.SetActive(false);
                                player1GloveMesh.SetActive(false);
                                yield return new WaitForSeconds(0.1f);
                                player1Mesh.SetActive(true);
                                player1SwordMesh.SetActive(true);
                                player1GloveMesh.SetActive(true);
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
                        p2Animator.SetBool("IsPunching", true);

                        yield return new WaitForSeconds(0.6f); // Time value is length from start of punch to impact

                        if (!isP1Dodging && !(P1Health.winState || P2Health.winState))
                        {
                            Invoke("Player2PunchEnd", 0.8f); // Time value is length from impact to end of punch

                            // Punch Successful (Not attacked by the other player before this punch's impact)
                            if (P1PunchDamage.otherPlayerCanAttack && !P2SliceDamage.playerInvincible && !P2PunchDamage.playerInvincible)
                            {
                                P1StunAnim.SetActive(false);
                                yield return new WaitForSeconds(0.01f);
                                P1Action = true;
                                P2Punch.SetActive(true);
                                p1Animator.SetBool("Damaged", true);
                                audioManager.PlaySFX(audioManager.punchHit, 0.5f);

                                yield return new WaitForSeconds(0.1f); // Time value is punch impact duration
                                P2Punch.SetActive(false);
                                p1Animator.SetBool("Damaged", false);

                                yield return new WaitForSeconds(1.4f);
                                P1Action = false;
                            }
                        }
                        else if (isP1Dodging && !P1SliceDamage.playerInvincible && !P1PunchDamage.playerInvincible)
                        {
                            // Punch was unsuccessful, player stunned
                            P2StunAnim.SetActive(true);
                            P1PunchDamage.otherPlayerCanAttack = true;

                            p2Animator.SetBool("IsStunned", true);
                            audioManager.PlaySFX(audioManager.blockSound, 1);
                            audioManager.PlaySFX(audioManager.stunSound, 1);

                            yield return new WaitForSeconds(1.6f); // Time value is stunned period
                            P2StunAnim.SetActive(false);
                            p2Animator.SetBool("IsStunned", false);
                            Player2PunchEnd();
                        }
                        else // Edge Case: Player attacks other's defence while invincible. Does not stun attacking player.
                        {
                            Invoke("Player2PunchEnd", 0.8f);
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
                        p2Animator.SetBool("IsDodging", true);

                        yield return new WaitForSeconds(0.5f); // Time [before] player is in dodging state

                        // Color Change (Yellow Emission)
                        if (P2Main.name == "Kachujin (P2)")
                        {
                            P2Emission.materials[0].EnableKeyword("_EMISSION");
                            P2Emission.materials[1].EnableKeyword("_EMISSION");
                            P2Emission.materials[0].globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            P2Emission.materials[1].globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                        }
                        if (P2Main.name == "Brute (P2)")
                        {
                            BruteEmission1.material.EnableKeyword("_EMISSION");
                            BruteEmission2.material.EnableKeyword("_EMISSION");
                            BruteEmission3.material.EnableKeyword("_EMISSION");
                            BruteEmission4.material.EnableKeyword("_EMISSION");
                            BruteEmission5.material.EnableKeyword("_EMISSION");
                            BruteEmission6.material.EnableKeyword("_EMISSION");
                            BruteEmission7.material.EnableKeyword("_EMISSION");
                            BruteEmission8.material.EnableKeyword("_EMISSION");
                            BruteEmission1.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission2.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission3.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission4.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission5.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission6.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission7.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission8.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                        }
                        else if (P2Main.name is "Ninja (P2)" or "Wrestler (P2)")
                        {
                            P2Emission.material.EnableKeyword("_EMISSION");
                            P2Emission.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                        }

                        isP2Dodging = true;
                        P2Dodge.SetActive(true);
                        audioManager.PlaySFX(audioManager.dodgeSound, 1.5f);

                        yield return new WaitForSeconds(0.6f); // Time [when] player is in dodging state

                        // End of Dodge
                        if (P2Main.name == "Kachujin (P2)")
                        {
                            P2Emission.materials[0].globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            P2Emission.materials[1].globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            P2Emission.materials[0].DisableKeyword("_EMISSION");
                            P2Emission.materials[1].DisableKeyword("_EMISSION");
                        }
                        else if (P2Main.name == "Brute (P2)")
                        {
                            BruteEmission1.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission2.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission3.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission4.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission5.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission6.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission7.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission8.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission1.material.DisableKeyword("_EMISSION");
                            BruteEmission2.material.DisableKeyword("_EMISSION");
                            BruteEmission3.material.DisableKeyword("_EMISSION");
                            BruteEmission4.material.DisableKeyword("_EMISSION");
                            BruteEmission5.material.DisableKeyword("_EMISSION");
                            BruteEmission6.material.DisableKeyword("_EMISSION");
                            BruteEmission7.material.DisableKeyword("_EMISSION");
                            BruteEmission8.material.DisableKeyword("_EMISSION");
                        }
                        else if (P2Main.name is "Ninja (P2)" or "Wrestler (P2)")
                        {
                            P2Emission.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            P2Emission.material.DisableKeyword("_EMISSION");
                        }

                        yield return new WaitForSeconds(0.2f);

                        isP2Dodging = false;
                        P2Dodge.SetActive(false);
                        Player2DodgeEnd();

                        yield return new WaitForSeconds(0.2f);
                        P2Action = false;
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
                        p2Animator.SetBool("IsSlicing", true);

                        yield return new WaitForSeconds(0.5f); // Time value is length from start of slice to impact

                        if (!isP1Deflecting && !(P1Health.winState || P2Health.winState))
                        {
                            Invoke("Player2SliceEnd", 0.8f); // Time value is length from impact to end of slice

                            // Slice Successful (Not attacked by the other player before this slice's impact)
                            if (P1SliceDamage.otherPlayerCanAttack && !P2SliceDamage.playerInvincible && !P2PunchDamage.playerInvincible)
                            {
                                P1StunAnim.SetActive(false);
                                yield return new WaitForSeconds(0.1f);
                                P1Action = true;
                                P2Slice.SetActive(true);
                                p1Animator.SetBool("Damaged", true);
                                audioManager.PlaySFX(audioManager.swordHit, 1);

                                yield return new WaitForSeconds(0.1f); // Time value is slice impact duration
                                P2Slice.SetActive(false);
                                p1Animator.SetBool("Damaged", false);

                                yield return new WaitForSeconds(1.4f);
                                P1Action = false;
                                P2Action = false;
                            }
                        }
                        else if (isP1Deflecting && !P1SliceDamage.playerInvincible && !P1PunchDamage.playerInvincible)
                        {
                            // Slice was unsuccessful, player stunned
                            P2StunAnim.SetActive(true);
                            P1SliceDamage.otherPlayerCanAttack = true;

                            p2Animator.SetBool("IsStunned", true);
                            audioManager.PlaySFX(audioManager.swordClash, 1);
                            yield return new WaitForSeconds(0.01f);
                            audioManager.PlaySFX(audioManager.stunSound, 1);

                            yield return new WaitForSeconds(1.6f); // Time value is stunned period
                            P2StunAnim.SetActive(false);
                            p2Animator.SetBool("IsStunned", false);
                            Player2SliceEnd();
                        }
                        else // Edge Case: Player attacks other's defence while invincible. Does not stun attacking player.
                        {
                            Invoke("Player2SliceEnd", 0.8f);
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
                        p2Animator.SetBool("IsDeflecting", true);

                        yield return new WaitForSeconds(0.2f); // Time [before] player is in deflecting state

                        // Color Change (Yellow Emission)
                        if (P2Main.name == "Kachujin (P2)")
                        {
                            P2Emission.materials[0].EnableKeyword("_EMISSION");
                            P2Emission.materials[1].EnableKeyword("_EMISSION");
                            P2Emission.materials[0].globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            P2Emission.materials[1].globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                        }
                        if (P2Main.name == "Brute (P2)")
                        {
                            BruteEmission1.material.EnableKeyword("_EMISSION");
                            BruteEmission2.material.EnableKeyword("_EMISSION");
                            BruteEmission3.material.EnableKeyword("_EMISSION");
                            BruteEmission4.material.EnableKeyword("_EMISSION");
                            BruteEmission5.material.EnableKeyword("_EMISSION");
                            BruteEmission6.material.EnableKeyword("_EMISSION");
                            BruteEmission7.material.EnableKeyword("_EMISSION");
                            BruteEmission8.material.EnableKeyword("_EMISSION");
                            BruteEmission1.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission2.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission3.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission4.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission5.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission6.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission7.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                            BruteEmission8.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                        }
                        else if (P2Main.name is "Ninja (P2)" or "Wrestler (P2)")
                        {
                            P2Emission.material.EnableKeyword("_EMISSION");
                            P2Emission.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                        }

                        isP2Deflecting = true;
                        P2Deflect.SetActive(true);
                        audioManager.PlaySFX(audioManager.deflectSound, 1);

                        yield return new WaitForSeconds(0.65f); // Time [when] player is in deflecting state

                        // End of Deflect
                        if (P2Main.name == "Kachujin (P2)")
                        {
                            P2Emission.materials[0].globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            P2Emission.materials[1].globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            P2Emission.materials[0].DisableKeyword("_EMISSION");
                            P2Emission.materials[1].DisableKeyword("_EMISSION");
                        }
                        else if (P2Main.name == "Brute (P2)")
                        {
                            BruteEmission1.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission2.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission3.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission4.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission5.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission6.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission7.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission8.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            BruteEmission1.material.DisableKeyword("_EMISSION");
                            BruteEmission2.material.DisableKeyword("_EMISSION");
                            BruteEmission3.material.DisableKeyword("_EMISSION");
                            BruteEmission4.material.DisableKeyword("_EMISSION");
                            BruteEmission5.material.DisableKeyword("_EMISSION");
                            BruteEmission6.material.DisableKeyword("_EMISSION");
                            BruteEmission7.material.DisableKeyword("_EMISSION");
                            BruteEmission8.material.DisableKeyword("_EMISSION");
                        }
                        else if (P2Main.name is "Ninja (P2)" or "Wrestler (P2)")
                        {
                            P2Emission.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                            P2Emission.material.DisableKeyword("_EMISSION");
                        }

                        isP2Deflecting = false;
                        P2Deflect.SetActive(false);
                        Player2DeflectEnd();

                        yield return new WaitForSeconds(0.2f);
                        P2Action = false;
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
                                player2SwordMesh.SetActive(false);
                                player2GloveMesh.SetActive(false);
                                yield return new WaitForSeconds(0.1f);
                                player2Mesh.SetActive(true);
                                player2SwordMesh.SetActive(true);
                                player2GloveMesh.SetActive(true);
                                yield return new WaitForSeconds(0.1f);
                            }
                        }
                    }
                }
                else if(P1Health.winTextObject.activeInHierarchy || P2Health.winTextObject.activeInHierarchy)
                {
                    buttons.SetActive(true);
                }

                yield return new WaitForSeconds(0.5f);
                StartTextObject.SetActive(false);
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
                p1Animator.SetBool("Defeated", true);
                p2Animator.SetBool("GameWon", true);

                yield return new WaitForSeconds(0.01f);

                p1Animator.SetBool("Defeated", false);
                p2Animator.SetBool("GameWon", false);

                // Fixes for Character Animation Inconcistency
                if (P1Main.name == "Brute (P1)")
                {
                    yield return new WaitForSeconds(2.25f);
                    P1Main.transform.position = new Vector3(P1Pos.x, P1Pos.y, P1Pos.z);
                }
                else if (P1Main.name == "Ninja (P1)")
                {
                    yield return new WaitForSeconds(2.25f);
                    P1Main.transform.position = new Vector3(P1Pos.x, P1Pos.y + 0.3f, P1Pos.z);
                }
                else if (P1Main.name == "Kachujin (P1)")
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
                P2Main.transform.position = new Vector3(P2Pos.x, (P2Pos.y + 0.4f), P2Pos.z);

                P1Main.transform.position = new Vector3(P1Pos.x, (P1Pos.y + 0.4f), P1Pos.z);
                p2Animator.SetBool("Defeated", true);
                p1Animator.SetBool("GameWon", true);

                yield return new WaitForSeconds(0.01f);

                p2Animator.SetBool("Defeated", false);
                p1Animator.SetBool("GameWon", false);

                // Fixes for Character Animation Inconsistency
                if (P2Main.name == "Brute (P2)")
                {
                    yield return new WaitForSeconds(2.25f);
                    P2Main.transform.position = new Vector3(P2Pos.x, P2Pos.y, P2Pos.z);
                }
                else if (P2Main.name == "Ninja (P2)")
                {
                    yield return new WaitForSeconds(2.25f);
                    P2Main.transform.position = new Vector3(P2Pos.x, P2Pos.y + 0.3f, P2Pos.z);
                }
                else if (P2Main.name == "Kachujin (P2)")
                {
                    yield return new WaitForSeconds(2.25f);
                    P2Main.transform.position = new Vector3(P2Pos.x, P2Pos.y + 0.1f, P2Pos.z);
                }
            }
        }
    }


    // Player 1 Void Functions
    void Player1PunchEnd()
    {
        Animator p1Animator = P1Animator.GetComponent<Animator>();
        StartCoroutine(P1ActionEnd());
        p1Animator.SetBool("IsPunching", false);

        // print("p1 punch end");
        player1Mesh.SetActive(true);
        P2PunchDamage.otherPlayerCanAttack = true;
        P1PunchDamage.otherPlayerCanAttack = true;
    }
    void Player1DodgeEnd()
    {
        Animator p1Animator = P1Animator.GetComponent<Animator>();
        p1Animator.SetBool("IsDodging", false);

        // print("p1 dodge end");
    }
    void Player1SliceEnd()
    {
        Animator p1Animator = P1Animator.GetComponent<Animator>();
        StartCoroutine(P1ActionEnd());
        p1Animator.SetBool("IsSlicing", false);

        // print("p1 slice end");
        player1Mesh.SetActive(true);
        P2SliceDamage.otherPlayerCanAttack = true;
        P1SliceDamage.otherPlayerCanAttack = true;
    }
    void Player1DeflectEnd()
    {
        Animator p1Animator = P1Animator.GetComponent<Animator>();
        p1Animator.SetBool("IsDeflecting", false);
        // print("p1 deflect end");
    }
    IEnumerator P1ActionEnd()
    {
        yield return new WaitForSeconds(0.2f);
        P1Action = false;
    }

    // Player 2 Void Functions
    void Player2PunchEnd()
    {
        Animator p2Animator = P2Animator.GetComponent<Animator>();
        StartCoroutine(P2ActionEnd());
        p2Animator.SetBool("IsPunching", false);

        // print("p2 punch end");
        player2Mesh.SetActive(true);
        P1PunchDamage.otherPlayerCanAttack = true;
        P2PunchDamage.otherPlayerCanAttack = true;
    }
    void Player2DodgeEnd()
    {
        Animator p2Animator = P2Animator.GetComponent<Animator>();
        p2Animator.SetBool("IsDodging", false);
        // print("p2 dodge end");
    }
    void Player2SliceEnd()
    {
        Animator p2Animator = P2Animator.GetComponent<Animator>();
        StartCoroutine(P2ActionEnd());
        p2Animator.SetBool("IsSlicing", false);

        // print("p2 slice end");
        player2Mesh.SetActive(true);
        P1SliceDamage.otherPlayerCanAttack = true;
        P2SliceDamage.otherPlayerCanAttack = true;
    }
    void Player2DeflectEnd()
    {
        Animator p2Animator = P2Animator.GetComponent<Animator>();
        p2Animator.SetBool("IsDeflecting", false);
        // print("p2 deflect end");
    }
    IEnumerator P2ActionEnd()
    {
        yield return new WaitForSeconds(0.2f);
        P2Action = false;
    }
}