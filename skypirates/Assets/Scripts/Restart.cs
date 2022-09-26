using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip buttonclick;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void RestartGame()
    {
        audioSource.PlayOneShot(buttonclick);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

     public void Title()
  {
        audioSource.PlayOneShot(buttonclick);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
  }

     public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}