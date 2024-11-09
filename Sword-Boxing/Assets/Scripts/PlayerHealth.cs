using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To access the unity ui elements, in this case being the square
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    // Health
    public float health;

    // Max Health
    float maxHealth;

    // Image of Health Bar
    public Image healthBar;

    // Win Text
    [SerializeField] TextMeshProUGUI winText;
    public GameObject winTextObject;

    // Start is called before the first frame update
    void Start()
    { 
        maxHealth = health;
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0)
        {
            winTextObject.SetActive(true);

            // Win State
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

            gameObject.SetActive(false);
        }

        // For testing (lowering health)
        if (Input.GetKeyUp(KeyCode.B))
        {
            health -= 5;
        }
    }
}