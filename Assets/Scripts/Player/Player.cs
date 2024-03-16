using System;
using System.Collections;
using System.Collections.Generic;
using RangeAttack;
using UnityEngine;
[RequireComponent(typeof(PlayerGearsManager))]
public class Player : MonoBehaviour, IDamageable {
    public static Player instance;
    [SerializeField] private int maxHp;
    [SerializeField] private int meleeDmg;
    [SerializeField] private int weaponDmg;
    [SerializeField] private float meleeAttackCooldown = 1f;
    [SerializeField] private float rangeAttackCooldown = 1f;
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private int numberOfJumps = 1;
    [SerializeField] private float jumpForce = 2f;


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
        jumpsLeft = numberOfJumps;
    }

    private void FixedUpdate()
    {
        movement = InputManager.navigationAxis;
        if (movement.y == 0)
        {
            canJump = true;
        }
        rb.velocity = new Vector2(-movement.x * movementSpeed * Time.deltaTime * 100, rb.velocity.y);

        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            isGrounded = true;
            jumpsLeft = numberOfJumps;
            canJump = true;
        }

        if (movement.y > 0 && (isGrounded || jumpsLeft > 0) && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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
        StartCoroutine(AttackMeleeCooldown(meleeAttackCooldown));
        StartCoroutine(MeleeHitBoxDisable(0.05f));
    }

    public void RangeAttack()
    {
        StartCoroutine(AttackRangeCooldown(rangeAttackCooldown));
        if (gearsManager.CanThrowGear()) {
            gearsManager.ThrowGear();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(meleeDmg + weaponDmg);
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
        Debug.Log("Dupa: " + amount);
    }

    public Transform GetTransform() {
        return transform;
    }
}
