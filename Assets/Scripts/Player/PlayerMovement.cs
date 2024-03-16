using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private int numberOfJumps = 1;

    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Player player;

    private int jumpsLeft;
    private bool isGrounded = true;
    private bool isFacingRight = false;
    private bool canJump = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        jumpsLeft = numberOfJumps;
        player = GetComponent<Player>();
    }

    void Update()
    {
        FlipSprite();
        if (movement.y == 0)
        {
            canJump = true;
        }

        if (movement.y > 0 && (isGrounded || jumpsLeft > 0) && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
            jumpsLeft -= 1;
            canJump = false;
        }
    }

    private void FixedUpdate()
    {
        Vector2 movement = player.GetMovement();
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetBool("isJumping", !isGrounded);
        animator.SetBool("isAttacking", player.GetIsAttacking());
    }

    void FlipSprite()
    {
        if (isFacingRight && movement.x < 0 || !isFacingRight && movement.x > 0)
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            isGrounded = true;
            jumpsLeft = numberOfJumps;
            canJump = true;
        }
    }
}
