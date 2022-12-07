using System.Collections;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 1f;

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
    void FixedUpdate()
    {
       
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
}
