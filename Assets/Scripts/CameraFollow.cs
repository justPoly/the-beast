// Handles Everything about Camera motion and activity

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 playerOffset = new Vector3(0f, -10f, -10f);
    public float cameraVelocity = 10f;

    [SerializeField] private Transform playerTransform;

    void Start()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }

    private void FixedUpdate()
    {
        //transform.position = new Vector3(playerTransform.position.x, transform.position.y,  transform.position.z);
        Vector3 targetPosition = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraVelocity);
    }
}
