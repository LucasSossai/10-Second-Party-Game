using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroText : MonoBehaviour
{

    public TextMeshProUGUI introText;
    public AudioClip introSound;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(ShowIntroText());
    }

    IEnumerator ShowIntroText()
    {
        if (introSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(introSound);
        }

        introText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        introText.gameObject.SetActive(false);
    }
    
}
