using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathnoise : MonoBehaviour
{
    private MainCharacterController mainCharacterController;

    void Awake()
    {
        GameObject mainCharacterControllerObject = GameObject.FindWithTag("MainCharacterController");
        mainCharacterController = mainCharacterControllerObject.GetComponent<MainCharacterController>();
        mainCharacterController.ChangeScore(50);
        Destroy(gameObject , 0.5f);

    }

}
