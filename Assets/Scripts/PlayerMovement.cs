using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 10f;
    public bool isGrounded;
    public int speed;

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
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        
        isGrounded = Physics2D.IsTouchingLayers(Collider, whatIsGrounded);

        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    public void PlayerJump()
    {
        if(isGrounded == true)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
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
