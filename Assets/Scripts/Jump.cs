using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpVelocity = 10f;

    // public float fallMultiplier = 10f;
    // public float lowJumpMultiplier = 5f;

    bool jumpRequest;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            jumpRequest = true;
        }
    }

    void FixedUpdate()
    {
        if(jumpRequest)
        {
            rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            jumpRequest = false;
        }

        // if(rb.velocity.y < 0)
        // {
        //     rb.gravityScale = fallMultiplier;
        // }
        // else if(rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space))
        // {
        //     rb.gravityScale = lowJumpMultiplier;
        // }
        // else
        // {
        //     rb.gravityScale = 1f;
        // }
    }
}
