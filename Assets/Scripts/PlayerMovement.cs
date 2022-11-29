using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 50f;
    public bool isGrounded;
    public int speed;
    public Transform groundCheck;

    public LayerMask whatIsGrounded;

    // public GameObject pan;

    private Collider2D Collider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Collider = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * Time.fixedDeltaTime * speed);
        
        isGrounded = Physics2D.IsTouchingLayers(Collider, whatIsGrounded);

        if(Input.GetMouseButtonDown(0) && isGrounded == true)
        {
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
        }
        /*
        if(rb.velocity.y <0)
        {
            rb.gravityScale = fallMultiplier;
        }
        else if(rb.velocity.y >0 && Input.GetButton("Jump"))
        {
            rb.gravityScale = lowJumpMultiplier;
        }
        else
        {
            rb.gravityScale = 1f;
        }*/
    }
    
    void OnCollisionEnter2D(Collision2D collision) 
    {
        // When target is hit
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            speed = 0;
            EnemyMovement.instance.speed = 0;
            GameManager.instance.GameOver();
        }
        
    }
    void OnCollisionExit2D(Collision2D collision) 
    {
        isGrounded = false;
        
        
    }

}
