using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class LockerController : MonoBehaviour
{
#pragma warning disable IDE0051 // Remove unused private members

    private bool P1Turn;
    private bool P2Turn;

    private bool P1DelayActive;
    private bool P2DelayActive;

    public static int P1characterSelection;
    public static int P2characterSelection;
    [HideInInspector] public int P1CS; // CS stands for Character Selection, these are static variable counterparts
    [HideInInspector] public int P2CS;

    public GameObject confirmationUI;
    public GameObject doubleSelectionText;
    public GameObject playerSelectPanel;
    public GameObject characterBioPanel;

    [SerializeField] TextMeshProUGUI selectionText;
    [SerializeField] TextMeshProUGUI player1Text;
    [SerializeField] TextMeshProUGUI player2Text;
    [SerializeField] TextMeshProUGUI bioText;

    public GameObject[] P1CharacterModel;
    public GameObject[] P2CharacterModel;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "BoxingRing")
        {
            P1Turn = true;
            P2Turn = false;
            P1DelayActive = false;
            P2DelayActive = false;
            selectionText.color = Color.red;
            selectionText.outlineColor = Color.red;
            P1characterSelection = 0;
            P2characterSelection = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Quit Application
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (SceneManager.GetActiveScene().name != "BoxingRing")
        {
            // ~ Player 1's Turn ~

            if (P1Turn)
            {
                if (P1characterSelection == 0)
                {
                    bioText.text = "<size=35>REX</size>\r\nAn amateur professional boxer who is down on his luck decides to test his fate in the ring." +
                    "\r\n\r\nFamous Quotes:\r\n\"I'm going to be top of the world, mark my words!\" \r\n\"I won't lose against anyone, especially you!\"";
                }
                if(P1characterSelection == 1)
                {
                    bioText.text = "<size=35>CRIMSON</size>\r\nA nimble yet ferocious combatant, she desires power over all and will defeat whoever stands in her way." +
                    "\r\n\r\nFamous Quotes:\r\n\"Don't underestimate me, you wouldn't last a minute against me in the ring.\" \r\n\"You will be my new stepping stone.\"";
                }
                if(P1characterSelection == 2)
                {
                    bioText.text = "<size=35>EL DEVIL</size>\r\nA popular wrestler, he decided to set his eyes on the big stage to boost his popularity to new heights." +
                    "\r\n\r\nFamus Quotes:\r\n\"Heard about me? You're going to be beaten by El Devil!\"\r\n\"Better bring your A game, you're going to bore the audience.\"";
                }
                if (P1characterSelection == 3) 
                {
                    bioText.text = "<size=35>JIN</size>\r\nAs an experienced assassin, he too wants to experience the thrill in the ring to hone his skills. " +
                    "By his nature, he is very reclusive and introverted.\r\n\r\nFamous Quotes:\r\n\"New target acquired.\" \r\n\"Prepare yourself.\"";
                }
            }

            if (P1Turn && !P1DelayActive && Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(P1Minus());
            }
            IEnumerator P1Minus()
            {
                P1DelayActive = true;
                P1CharacterModel[P1characterSelection].SetActive(false);
                yield return new WaitForSeconds(0.01f);

                if (P1characterSelection == 0)
                {
                    P1characterSelection = 3;
                }
                else
                {
                    P1characterSelection--;
                }

                P1CharacterModel[P1characterSelection].SetActive(true);
                characterBioPanel.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                P1DelayActive = false;
            }

            if (P1Turn && !P1DelayActive && Input.GetKeyDown(KeyCode.S))
            {
                StartCoroutine(P1Plus());
            }
            IEnumerator P1Plus()
            {
                P1DelayActive = true;
                P1CharacterModel[P1characterSelection].SetActive(false);
                yield return new WaitForSeconds(0.01f);

                if (P1characterSelection == 3)
                {
                    P1characterSelection = 0;
                }
                else
                {
                    P1characterSelection++;
                }

                P1CharacterModel[P1characterSelection].SetActive(true);
                characterBioPanel.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                P1DelayActive = false;
            }

            // End of P1's Turn
            if (P1Turn && Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(P1TurnEnd());
            }
            IEnumerator P1TurnEnd()
            {
                yield return new WaitForSeconds(0.01f);
                P1Turn = false;
                P2Turn = true;
                P1CharacterModel[P1characterSelection].SetActive(false);
                if (P1characterSelection == 3)
                {
                    P2characterSelection = 0;
                }
                else
                {
                    P2characterSelection = P1characterSelection + 1;
                }
                P2CharacterModel[P2characterSelection].SetActive(true);

                selectionText.color = Color.blue;
                selectionText.outlineColor = Color.blue;
                selectionText.text = "~ Player 2 Select ~\r\n<size=20>Switch characters with K and L                keys and select with Spacebar";
            }



            // ~ Player 2's Turn ~

            if (P2Turn)
            {
                if (P2characterSelection == 0)
                {
                    bioText.text = "<size=35>REX</size>\r\nAn amateur professional boxer who is down on his luck decides to test his fate in the ring." +
                    "\r\n\r\nFamous Quotes:\r\n\"I'm going to be top of the world, mark my words!\" \r\n\"I won't lose against anyone, especially you!\"";
                }
                if (P2characterSelection == 1)
                {
                    bioText.text = "<size=35>CRIMSON</size>\r\nA nimble yet ferocious combatant, she desires power over all and will defeat whoever stands in her way." +
                    "\r\n\r\nFamous Quotes:\r\n\"Don't underestimate me, you wouldn't last a minute against me in the ring.\" \r\n\"You will be my new stepping stone.\"";
                }
                if (P2characterSelection == 2)
                {
                    bioText.text = "<size=35>EL DEVIL</size>\r\nA popular wrestler, he decided to set his eyes on the big stage to boost his popularity to new heights." +
                    "\r\n\r\nFamus Quotes:\r\n\"Heard about me? You're going to be beaten by El Devil!\"\r\n\"Better bring your A game, you're going to bore the audience.\"";
                }
                if (P2characterSelection == 3)
                {
                    bioText.text = "<size=35>JIN</size>\r\nAs an experienced assassin, he too wants to experience the thrill in the ring to hone his skills. " +
                    "By his nature, he is very reclusive and introverted.\r\n\r\nFamous Quotes:\r\n\"New target acquired.\" \r\n\"Prepare yourself.\"";
                }
            }

            if (P2Turn && !P2DelayActive && Input.GetKeyDown(KeyCode.K))
            {
                StartCoroutine(P2Minus());
            }
            IEnumerator P2Minus()
            {
                P2DelayActive = true;
                P2CharacterModel[P2characterSelection].SetActive(false);
                doubleSelectionText.SetActive(false);
                yield return new WaitForSeconds(0.01f);

                if (P2characterSelection == 0)
                {
                    P2characterSelection = 3;
                }
                else
                {
                    P2characterSelection--;
                }

                P2CharacterModel[P2characterSelection].SetActive(true);
                characterBioPanel.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                P2DelayActive = false;
            }

            if (P2Turn && !P2DelayActive && Input.GetKeyDown(KeyCode.L))
            {
                StartCoroutine(P2Plus());
            }
            IEnumerator P2Plus()
            {
                P2DelayActive = true;
                P2CharacterModel[P2characterSelection].SetActive(false);
                doubleSelectionText.SetActive(false);
                yield return new WaitForSeconds(0.01f);

                if (P2characterSelection == 3)
                {
                    P2characterSelection = 0;
                }
                else
                {
                    P2characterSelection++;
                }

                P2CharacterModel[P2characterSelection].SetActive(true);
                characterBioPanel.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                P2DelayActive = false;
            }

            // End of P2's Turn and Confirmation UI Made Visible
            if (P2Turn && Input.GetKeyDown(KeyCode.Space) && P2characterSelection != P1characterSelection)
            {
                player1Text.text = "Player 1 is " + P1CharacterModel[P1characterSelection].name;
                player1Text.outlineColor = Color.red;
                player2Text.text = "Player 2 is " + P2CharacterModel[P2characterSelection].name;
                player2Text.outlineColor = Color.blue;

                characterBioPanel.SetActive(false);
                playerSelectPanel.SetActive(false);
                confirmationUI.SetActive(true);
                P2CharacterModel[P2characterSelection].SetActive(false);
            }
            else if (P2Turn && Input.GetKeyDown(KeyCode.Space) && P2characterSelection == P1characterSelection)
            {
                doubleSelectionText.SetActive(true);
                characterBioPanel.SetActive(false);
            }
        }
        else
        {
            P1CS = P1characterSelection;
            P2CS = P2characterSelection;
        }
    }
}
