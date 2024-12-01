using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
#pragma warning disable IDE0051 // Remove unused private members

    public string TransScreen;

    GameObject audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio");
    }

    public void Button()
    {
        Invoke("ButtonDelay", 0.5f);

        if (SceneManager.GetActiveScene().name == "LockerRoom")
        {
            Destroy(audioManager);
        }
    }
    void ButtonDelay()
    {
        SceneManager.LoadScene(TransScreen);
    }

    public void Reload()
    {
        Invoke("ReloadDelay", 0.3f);
    }

    void ReloadDelay()
    {
        SceneManager.LoadScene("LockerRoom");
    }
}
