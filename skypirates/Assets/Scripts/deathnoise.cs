using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathnoise : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject , 0.4f);
    }

}
