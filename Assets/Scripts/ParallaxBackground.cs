using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
     [SerializeField] private float parallaxEffectMultiplier;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;
    

    private void Start() {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = (texture.width / sprite.pixelsPerUnit) * transform.localScale.x;
       
    }

    private void FixedUpdate() {
       Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
       float parallaxEffectMultiplier = .5f;
       transform.position += deltaMovement * parallaxEffectMultiplier;
       lastCameraPosition = cameraTransform.position;

       if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX) {
           float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
           transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
       }
       
       
    }
}
