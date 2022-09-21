using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    [SerializeField]
    private float flashTime;

    public MeshRenderer ren;

    Color originalColor; 

    void Start()
    {
        originalColor = ren.material.color;
        Flash();
        flashTime = 3;
    }

    void Flash()
    {
        ren.material.color = Color.red;
        Invoke("ResetColor", flashTime);
    }

    void ResetColor()
    {
        ren.material.color = originalColor;
    }
}
