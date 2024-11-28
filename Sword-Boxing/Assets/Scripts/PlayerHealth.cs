using System.Collections;
using System.Collections.Generic;
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
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0)
        {
            StartCoroutine(GameEnd());
        }
        IEnumerator GameEnd()
        {
            yield return new WaitForSeconds(0.01f);
            gameObject.SetActive(false);

            // Win State
            winState = true;

            winTextObject.SetActive(true);
            if (name == "Player1")
            {
                winText.text = "Player 2 Wins! Press R to restart";
                winText.color = Color.blue;
            }

            if (name == "Player2")
            {
                winText.text = "Player 1 Wins! Press R to restart";
                winText.color = Color.red;
            }

            yield return new WaitForSeconds(0.5f); // Edit this time value as needed to line up with voicelines
            // SOUND: "Congratulations" SFX

            yield return new WaitForSeconds(0.5f); // Edit this time value as needed to line up with voicelines
            // SOUND: "You Win" SFX
        }
    }
}