using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] float remainingTime = 60f;
    private bool timerActive = false;
    private bool gameWon = false;
    public BackgroundMusic backgroundMusicScript;
    public AudioClip winSound;
    public AudioClip loseSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameOverText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        StartCoroutine(DelayTimerStart());
    }

    void Update()
    {
        if (timerActive && !gameWon)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime <= 0)
            {
                remainingTime = 0;
                timerText.color = Color.red;
                timerActive = false;
                gameOverText.gameObject.SetActive(true);
                gameOverText.text = "You Lost!";
                Time.timeScale = 0;

                if (audioSource != null && loseSound != null)
                {
                    audioSource.PlayOneShot(loseSound);
                }

                if (backgroundMusicScript != null)
                {
                    backgroundMusicScript.StopMusic();
                }
            }

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void OnWin()
    {
        if (!gameWon)
        {
            gameWon = true;
            timerActive = false;
            winText.gameObject.SetActive(true);
            winText.text = "You Win!";
            Time.timeScale = 0;

            if (audioSource != null && winSound != null)
            {
                audioSource.PlayOneShot(winSound);
            }

            if (backgroundMusicScript != null)
            {
                backgroundMusicScript.StopMusic();
            }
        }
    }

    private IEnumerator DelayTimerStart()
    {
        yield return new WaitForSeconds(2f);
        timerText.gameObject.SetActive(true);
        timerActive = true;
    }
}
