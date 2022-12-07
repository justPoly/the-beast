using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 45f;
    public bool isGrounded;
    public int speed;
    public Transform groundCheck;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 1f;

    public LayerMask whatIsGrounded;
    private Collider2D Collider;
    public static PlayerMovement instance;

    private void Awake()
    {
        instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Collider = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
    }

    void FixedUpdate()
    {
        PlayerMoveRight();
        
        if(rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier;
        }
        else if(rb.velocity.y > 0 && !Input.GetMouseButtonDown(0))
        {
            rb.gravityScale = lowJumpMultiplier;
        }
        else
        {
            rb.gravityScale = 1f;
        }

    }

    public void PlayerMoveRight()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

    public void PlayerJump()
    { 
        isGrounded = Physics2D.IsTouchingLayers(Collider, whatIsGrounded);

        if(Input.GetMouseButtonDown(0) && isGrounded == true && GameManager.instance.isGameOver == false)
        {
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
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
            rb.velocity = Vector2.zero;
            jumpForce = 0;
            
            GameManager.instance.GameOver();
        }
        
    }
    void OnCollisionExit2D(Collision2D collision) 
    {
        isGrounded = false;
        
        
    }

}
