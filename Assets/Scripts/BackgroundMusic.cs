using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip backgroundMusic;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayMusicWithDelay());
    }

    IEnumerator PlayMusicWithDelay()
    {
        yield return new WaitForSeconds(2f);

        if (backgroundMusic != null && audioSource != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = false;
            audioSource.Play();
        }

        yield return new WaitForSeconds(11f);

        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
