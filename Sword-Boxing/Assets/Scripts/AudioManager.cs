using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clip --------")]

    // BGM:
    public AudioClip boxingBGM;
    public AudioClip lockerBGM;

    // SFX:
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
    public AudioClip bellSound;
    public AudioClip congratulations;
    public AudioClip youWin;

    public void PlaySFX(AudioClip clip, float volume = 1.0f) // Default Volume Value
    {
        SFXSource.PlayOneShot(clip, volume);
    }
}
