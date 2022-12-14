using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{   
    public Animator transition;
    public float transitionTime;
    
    [SerializeField]
    private GameObject screenSwiper;

    public Sprite newArt;



    public void LoadNextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex <= 3)
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));   
        }
        else if(MainCharacterController.score > 5000)
        {
            SceneManager.LoadScene("Win");
        }
        else if(MainCharacterController.score < 5000)
        {
            SceneManager.LoadScene("Lose");
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {   
        if(screenSwiper != null && newArt != null)
        {
            ChangeArt();
        }
        
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    private void ChangeArt()
    {
        screenSwiper.GetComponent<Image>().sprite = newArt;
    }


}
