using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private float movementSpeed = 1f;

    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;

    private bool isGrounded = true;
    private bool isFacingRight = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FlipSprite();
        if (movement.y > 0 && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }
    }

    private void FixedUpdate()
    {
        movement = InputManager.navigationAxis;
        rb.velocity = new Vector2(-movement.x * movementSpeed * Time.deltaTime * 100, rb.velocity.y);
        Debug.Log(rb.velocity);
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void FlipSprite()
    {
        if (isFacingRight && movement.x < 0 || !isFacingRight && movement.x > 0)
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
    }
}
