using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  AudioSource audioSource;
  public AudioClip buttonclick;

void Start()
{
  audioSource = GetComponent<AudioSource>();
}
  public void StartGame()
  {
    audioSource.PlayOneShot(buttonclick);
    SceneManager.LoadScene(1);
  }

  public void Quit()
  {
    audioSource.PlayOneShot(buttonclick);
    Application.Quit();
  }

  public void SeeControls()
  {
    audioSource.PlayOneShot(buttonclick);
    mainMenuScreen.SetActive(false);
    ctrlsScreen.SetActive(true);
    creditsScreen.SetActive(false);
  }

  public void SeeCredits()
  {
    audioSource.PlayOneShot(buttonclick);
    mainMenuScreen.SetActive(false);
    ctrlsScreen.SetActive(false);
    creditsScreen.SetActive(true);
  }

  public void GoBack()
  {
    audioSource.PlayOneShot(buttonclick);
    mainMenuScreen.SetActive(true);
    ctrlsScreen.SetActive(false);
    creditsScreen.SetActive(false);
  }

  [SerializeField]
  GameObject mainMenuScreen, ctrlsScreen, creditsScreen;
}