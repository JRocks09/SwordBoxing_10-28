using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
#pragma warning disable IDE0051 // Remove unused private members

    [Header("-------- Audio Sources --------")]
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clips --------")]

    // BGM:
    public AudioClip boxingBGM;

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
