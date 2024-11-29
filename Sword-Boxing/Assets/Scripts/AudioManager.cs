using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clip --------")]
    /* BGM:
    public AudioClip background;
    */
    public AudioClip damageTaken;
    public AudioClip hitSound;
    public AudioClip BGM;
    
    private void Start() 

    {
         musicSource.clip = BGM;
         musicSource.Play();
    }

    public void PlaySFX(AudioClip clip, float volume = 1.0f) // Default Volume Value
    {
        SFXSource.PlayOneShot(clip, volume);
    }
}
