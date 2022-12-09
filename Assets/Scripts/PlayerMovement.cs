using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [FancyHeader("PLAYER MOVEMENT", 3f, "#D4AF37", 8.5f, order = 0)]
    [Space]

    [Header("Moving")]
    private Rigidbody2D rb;
    public bool isGrounded;
    public int speed;
    public Transform groundCheck;
    public LayerMask whatIsGrounded;
    private Collider2D Collider;
    
    [Header("Jumping")]
    public float jumpForce = 45f;
    public float jumpTime = 0.3f;
    public float jumpTimeCounter;
    private bool isJumping;
    
    [Header("Animation")]
    private Animator animator;

  
    
    public static PlayerMovement instance;

    private void Awake()
    {
        instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
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
        
        // if(rb.velocity.y < 0)
        // {
        //     rb.gravityScale = fallMultiplier;
        // }
        // else if(rb.velocity.y > 0 && !Input.GetMouseButtonDown(0))
        // {
        //     rb.gravityScale = lowJumpMultiplier;
        // }
        // else
        // {
        //     rb.gravityScale = 1f;
        // }

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
            AudioManager.instance.PlayOneShot("Jump");
            animator.SetBool("Jumping", true);
            isGrounded = false;
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
        } else
        {
            animator.SetBool("Jumping", false);
        }

        if(Input.GetMouseButton(0) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
             animator.SetBool("Jumping", true);
             isGrounded = false;
             rb.velocity = new Vector2(rb.velocity.x, jumpForce);
             jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
                animator.SetBool("Jumping", false);
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            isJumping = false;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision) 
    {
        // When target is hit
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            AudioManager.instance.PlayOneShot("Hard Fall");
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
