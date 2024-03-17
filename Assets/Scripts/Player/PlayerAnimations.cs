using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private Vector2 velocity;
    private Vector2 movement;
    private Player player;

    private bool isFacingRight = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        FlipSprite();
    }

    private void FixedUpdate()
    {
        velocity = player.GetVelocity();
        animator.SetFloat("xVelocity", Mathf.Abs(velocity.x));
        animator.SetFloat("yVelocity", velocity.y);
        animator.SetBool("isJumping", !player.GetIsGrounded());
    }

    void FlipSprite()
    {
        movement = player.GetMovement();
        if (isFacingRight && movement.x < 0 || !isFacingRight && movement.x > 0)
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }    
    }

    public void AttackMelee()
    {
        animator.SetTrigger("AttackMelee");
    }

    public void AttackRange() {
        animator.SetTrigger("AttackRange");
    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
    }
}
