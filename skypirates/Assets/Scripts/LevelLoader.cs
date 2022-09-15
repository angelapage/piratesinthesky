using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{   

    
    public static void LoadNextLevel()
    {
        int nextLevelNum;
        
            nextLevelNum =  SceneManager.GetActiveScene().buildIndex + 1;

            if(nextLevelNum < SceneManager.sceneCountInBuildSettings)
            {
                 SceneManager.LoadScene(nextLevelNum);
            }
           
    }


}
