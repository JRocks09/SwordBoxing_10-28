using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager2 : MonoBehaviour
{
#pragma warning disable IDE0051 // Remove unused private members

    [Header("-------- Audio Sources --------")]
    [SerializeField] AudioSource MusicSource;

    [Header("-------- Audio Clips --------")]

    // BGM:
    public AudioClip lockerBGM;

    private void Awake()
    {
        PlayMusic(lockerBGM);
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(AudioClip clip, float volume = 0.5f) // Default Volume Value
    {
        MusicSource.PlayOneShot(clip, volume);
    }
}
