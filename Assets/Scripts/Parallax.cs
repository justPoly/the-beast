using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Parallax : MonoBehaviour
{

    [SerializeField] private Vector2 parallaxEffectMultiplier;
    private Transform cameraTRansform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;

   

    private void Start()
    {
        cameraTRansform = Camera.main.transform;
        lastCameraPosition = cameraTRansform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width/ sprite.pixelsPerUnit; 
        }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTRansform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x* parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTRansform.position;
        if(Mathf.Abs(cameraTRansform.position.x-transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = (cameraTRansform.position.x - transform.position.x) % textureUnitSizeX; 
            transform.position = new Vector3(cameraTRansform.position.x, transform.position.y);
        }
        }
}