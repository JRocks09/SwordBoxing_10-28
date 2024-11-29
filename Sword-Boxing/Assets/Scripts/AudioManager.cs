using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clip --------")]
    //BGM:
    public AudioClip boxingBGM;
    public AudioClip lockerBGM;
    //public AudioClip maleHurt;
    //public AudioClip femaleHurt;
    // Note: I don't know how to put them in the Damage Script so I replaced it with a generic 8-bit sound for damage taken
    public AudioClip damageTaken;
    public AudioClip punchHit;
    public AudioClip blockSound;
    public AudioClip swordSwing;
    public AudioClip swordHit;
    public AudioClip swordClash;
    public AudioClip deflectSound;
    public AudioClip dodgeSound;
    public AudioClip stunSound;
    public AudioClip readySound;
    public AudioClip goSound;
    //public AudioClip bellSound;
    // Note:  Attempted to do bell sound when game ends; it didn't work for player 2 win; unsure why and it is extremely loud so set it at 0.04
    private void Start()
    {
        // musicSource.clip = BGM;
        // musicSource.Play();
    }

    public void PlaySFX(AudioClip clip, float volume = 1.0f) // Default Volume Value
    {
        SFXSource.PlayOneShot(clip, volume);
    }
}
