using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Vector3 offset = new Vector3(0f,0f,-10f);

    public float smoothtime = 0.25f;
    
    private Vector3 velocity = Vector3.zero;
    [SerializeField] 
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position +offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothtime);
    }
    
}
