using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float Jumpforce;
    private Rigidbody2D rb;

    public Transform groundCheck;
    public float groudCheckRadius;
    public LayerMask groundLayer;
    private bool grounded;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groudCheckRadius, groundLayer);
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, rb.velocity.y);
        if (Input.GetKey(KeyCode.Space) && grounded) {
            rb.velocity = new Vector2(rb.velocity.x, Jumpforce);
        }
    }
}
