using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
  AudioSource audioSource;
  public AudioClip buttonclick;

  public Button startButton = null;
  public Button ctrlBackButton = null;
  public Button credBackButton = null;

  void Start()
  {
    audioSource = GetComponent<AudioSource>();
    startButton.Select();
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

    ctrlBackButton.Select();
  }

  public void SeeCredits()
  {
    audioSource.PlayOneShot(buttonclick);
    mainMenuScreen.SetActive(false);
    ctrlsScreen.SetActive(false);
    creditsScreen.SetActive(true);

    credBackButton.Select();
  }

  public void GoBack()
  {
    audioSource.PlayOneShot(buttonclick);
    mainMenuScreen.SetActive(true);
    ctrlsScreen.SetActive(false);
    creditsScreen.SetActive(false);

    startButton.Select();
  }

  [SerializeField]
  GameObject mainMenuScreen = null, ctrlsScreen = null, creditsScreen = null;
}