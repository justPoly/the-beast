using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 10f;
    public bool isGrounded;
    public int speed;
<<<<<<< HEAD
    public LayerMask whatIsGrounded;

    private Collider2D myCollider;
=======

    public LayerMask whatIsGrounded;

    private Collider2D Collider;
    
>>>>>>> e0a4db89bbbdd8767e04c48698f86bbf7d22376b
    // Start is called before the first frame update
    public static EnemyMovement instance;
    private void Awake() {
        instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
<<<<<<< HEAD
=======

        Collider = GetComponent<Collider2D>();

>>>>>>> e0a4db89bbbdd8767e04c48698f86bbf7d22376b
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
<<<<<<< HEAD
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 4);
=======
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 3);
        isGrounded = Physics2D.IsTouchingLayers(Collider, whatIsGrounded);
>>>>>>> e0a4db89bbbdd8767e04c48698f86bbf7d22376b

        if(hit.collider != null)
        {
            Debug.Log(hit.collider.tag);
            if(hit.collider.tag == "Obstacle")
            {
                Debug.Log(hit.collider.tag);
                if(isGrounded == true)
                {
                    isGrounded = false;
                    rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                    
                }
            }
            if(hit.collider.tag == "LongObstacle")
            {
                Debug.Log(hit.collider.tag);
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
