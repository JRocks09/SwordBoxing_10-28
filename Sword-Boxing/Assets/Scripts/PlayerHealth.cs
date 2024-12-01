using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerHealth : MonoBehaviour
{
#pragma warning disable IDE0051 // Remove unused private members

    // Health Variables
    public float health;
    private float maxHealth;

    // Image of Health Bar
    public Image healthBar;

    CapsuleCollider capsuleCollider;

    // Win Text
    [SerializeField] TextMeshProUGUI winText;
    public GameObject winTextObject;

    // Win State Variable
    [HideInInspector] public bool winState;

    // Sound
    AudioManager audioManager;

    void Start()
    { 
        maxHealth = health;
        winTextObject.SetActive(false);
        winState = false;

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
        capsuleCollider.enabled = true;
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health == 0)
        {
            StartCoroutine(GameEnd());
            health--;
        }
        IEnumerator GameEnd()
        {
            yield return new WaitForSeconds(0.01f);
            capsuleCollider.enabled = false;
            audioManager.PlaySFX(audioManager.bellSound, 0.4f);

            // Win State
            winState = true;
            yield return new WaitForSeconds(1);
            audioManager.PlaySFX(audioManager.youWin, 1.2f);

            winTextObject.SetActive(true);
            if (name == "Player1")
            {
                winText.text = "Player 2 Wins!";
                winText.color = Color.blue;
            }

            if (name == "Player2")
            {
                winText.text = "Player 1 Wins!";
                winText.color = Color.red;
            }

            yield return new WaitForSeconds(1.5f);
            audioManager.PlaySFX(audioManager.congratulations, 1.2f);
        }
    }
}