using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void StartGame()
  {
    SceneManager.LoadScene(1);
  }

  public void Quit()
  {
    Application.Quit();
  }


  public void SeeControls()
  {
    mainMenuScreen.SetActive(false);
    ctrlsScreen.SetActive(true);
    creditsScreen.SetActive(false);
  }

  public void SeeCredits()
  {
    mainMenuScreen.SetActive(false);
    ctrlsScreen.SetActive(false);
    creditsScreen.SetActive(true);
  }

  public void GoBack()
  {
    mainMenuScreen.SetActive(true);
    ctrlsScreen.SetActive(false);
    creditsScreen.SetActive(false);
  }

  [SerializeField]
  GameObject mainMenuScreen, ctrlsScreen, creditsScreen;

}
