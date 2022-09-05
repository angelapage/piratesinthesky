using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackgrounds : MonoBehaviour
{
    private Transform cam;
    private Vector3 lastCamPos;
    [SerializeField]
    float parallaxMultiplier;
    private float textureUnitsizeY;
    void Start()
    {
        cam = Camera.main.transform;
        lastCamPos = cam.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitsizeY = texture.height / sprite.pixelsPerUnit;

    }

    
    void LateUpdate()
    {
        Vector3 deltaMovement = cam.position - lastCamPos;
        transform.position += deltaMovement * parallaxMultiplier;
        lastCamPos = cam.position;

        if(cam.position.y - transform.position.y >= textureUnitsizeY)
        {
            float offsetPositionY = (cam.position.y - transform.position.y) % textureUnitsizeY;
            transform.position = new Vector3(cam.position.y + offsetPositionY, transform.position.y);
        }
    }
}
