using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Vector3 offset = new Vector3(4f,-10f,-10f);

    public float smoothtime = 0.25f;
    
    private Vector3 velocity = Vector3.zero;
    [SerializeField] 
    private Transform target;

    // void Awake()
    // {
    //     offset = transform.position = target.position;
    // }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        targetPosition.y = 5f;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothtime);
    }
    
}
