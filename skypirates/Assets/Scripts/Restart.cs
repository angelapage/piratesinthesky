using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip buttonclick;

    public LevelLoader startLevel = null;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void RestartGame()
    {
        audioSource.PlayOneShot(buttonclick);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

     public void Title()
  {
        audioSource.PlayOneShot(buttonclick);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        AudioListener.pause = false;
  }

     public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}