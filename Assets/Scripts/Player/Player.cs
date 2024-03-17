using System;
using System.Collections;
using System.Collections.Generic;
using RangeAttack;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerGearsManager))]
public class Player : MonoBehaviour, IDamageable {
    public static Player instance;

    [SerializeField] private BoxCollider2D meleeAttackCollider;

    private bool isAttackingMelee;
    private bool isAttackingRange;
    private Vector2 movement;
    private Rigidbody2D rb;
    private PlayerGearsManager gearsManager;
    private PlayerAnimations animations;
    private bool canJump = false;
    private bool isGrounded = true;
    private int jumpsLeft;

    private PlayerStatistics stats;

    public UnityEvent onPlayerDead;

    private void Awake() {
        instance = this;
    }

    private void Start()
    {
        InputManager.input.Player.MeleeAttack.performed += TriggerMeleeAttack;
        InputManager.input.Player.RangeAttack.performed += TriggerRangeAttack;
        rb = GetComponent<Rigidbody2D>();
        animations = GetComponent<PlayerAnimations>();
        gearsManager = GetComponent<PlayerGearsManager>();
        gearsManager.ResetGearSetup();
        
        stats = GetComponent<PlayerStatistics>();
        jumpsLeft = stats.NumberOfJumps;
    }

    private void FixedUpdate()
    {
        movement = InputManager.navigationAxis;
        if (movement.y == 0)
        {
            canJump = true;
        }
        rb.velocity = new Vector2(-movement.x * stats.MovementSpeed * Time.deltaTime * 100, rb.velocity.y);

        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            isGrounded = true;
            jumpsLeft = stats.NumberOfJumps;
            canJump = true;
        }

        if (movement.y > 0 && (isGrounded || jumpsLeft > 0) && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, stats.JumpForce);
            isGrounded = false; 
            jumpsLeft -= 1;
            canJump = false;
            animations.Jump();
        }
    }
    void TriggerMeleeAttack(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (isAttackingMelee) return;
        isAttackingMelee = true;
        animations.AttackMelee();
    }

    void TriggerRangeAttack(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (isAttackingRange) return;
        isAttackingRange = true;
        animations.AttackRange();
    }

    public void MeleeAttack()
    {
        meleeAttackCollider.enabled = true;
        StartCoroutine(AttackMeleeCooldown(stats.MeleeAttackCooldown));
        StartCoroutine(MeleeHitBoxDisable(0.05f));
    }

    public void RangeAttack()
    {
        StartCoroutine(AttackRangeCooldown(stats.RangeAttackCooldown));
        if (gearsManager.CanThrowGear()) {
            gearsManager.ThrowGear(transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(stats.MeleeDMG + stats.WeaponDMG);
        }
    }

    IEnumerator AttackMeleeCooldown(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isAttackingMelee = false;
    }

    IEnumerator AttackRangeCooldown(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isAttackingRange = false;
    }

    IEnumerator MeleeHitBoxDisable(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        meleeAttackCollider.enabled = false;
    }

    public Vector2 GetMovement() { return movement; }
    public Vector2 GetVelocity() { return rb.velocity; }
    public bool GetIsGrounded() {  return isGrounded; }

    public void TakeDamage(float amount) {
        stats.TakeDamage(amount);
    }

    public Transform GetTransform() {
        //Debug.Log("tranform");
        return transform;
    }
}
