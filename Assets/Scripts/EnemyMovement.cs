using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 9f;
    public bool isGrounded;
    public int speed;

    public LayerMask whatIsGrounded;

    private Collider2D Collider;
    public bool canJump;

    [SerializeField] 
    private Transform target;

    [Header("Animation")]
    private Animator anim;
    
    // Start is called before the first frame update
    public static EnemyMovement instance;
    private void Awake() {
        instance = this;
    }
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        
        Collider = GetComponent<Collider2D>();

        anim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void FixedUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        if(Vector2.Distance(transform.position, target.position) >5)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed *Time.deltaTime);
        //transform.Translate(Vector2.right * Time.fixedDeltaTime * speed);
        }
        CheckForObstacles();
<<<<<<< HEAD
    }
    void FixedUpdate()
    {
        
=======
>>>>>>> 787069a4e3f030d0212d1ad30b88e877066d0102
        
        
    }
    public void CheckForObstacles()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 3);
        isGrounded = Physics2D.IsTouchingLayers(Collider, whatIsGrounded);

        if(hit.collider != null)
        {  
            if(hit.collider.tag == "Obstacle")
            {
                canJump = true;
                
                Debug.Log(hit.collider.tag);
                if(isGrounded == true && canJump == true)
                {
                    anim.SetBool("isJumping", true);
                    canJump = false;
                    isGrounded = false;
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    
                    
                } else
                {
                    anim.SetBool("isJumping", false);
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
        if(collision.gameObject.CompareTag("Player") && GameManager.instance.isGameOver == true)
        {
            rb.velocity = Vector2.zero;
            jumpForce = 0;
            speed =0;
            canJump = false;
        }
        
    }
    void OnCollisionExit2D(Collision2D collision) 
    {
        isGrounded = false;
        
        
    }
    /*void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Obstacle")// When target is hit
        {
            if(isGrounded == true)
            {
                isGrounded = false;
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }
        
    }*/
}
