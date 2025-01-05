using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource BackGroundsource;
    public AudioSource sfxSource;

    public AudioClip ShootClip;
    public AudioClip deadClip;
    public AudioClip backgroundClip;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        PhatNhacNen();
    }
    void PhatNhacNen()
    {
        BackGroundsource.clip = backgroundClip;
        BackGroundsource.Play();
    }

    public void PlayShootingClip()
    {
        sfxSource.PlayOneShot(ShootClip);
    }
    public void PlayDeadClip()
    {
        sfxSource.PlayOneShot(deadClip);
    }
}
