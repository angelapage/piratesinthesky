using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlScript : MonoBehaviour
{
    public GameObject collectEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Collected()
    {
        Instantiate(collectEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
