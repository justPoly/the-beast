using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 10f;
    public bool isGrounded;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 3);

        if(hit.collider != null)
        {
            Debug.Log(hit.collider.tag);
            if(hit.collider.tag == "Obstacle")
            {
                if(isGrounded == true)
                {
                    isGrounded = false;
                    rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                }
            }
            //if(hit.collider.gameObject.name)
        }
        
        
    }
    
    void OnCollisionEnter2D(Collision2D collision) 
    {
        // When target is hit
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
    }
    void OnCollisionExit2D(Collision2D collision) 
    {
        isGrounded = false;
        
        
    }
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Obstacle")// When target is hit
        {
            if(isGrounded == true)
            {
                isGrounded = false;
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }
        
    }
}
