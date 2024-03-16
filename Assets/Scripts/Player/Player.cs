using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable {
    public static Player instance;
    [SerializeField] private int maxHp;
    [SerializeField] private int meleeDmg;
    [SerializeField] private int weaponDmg;
    [SerializeField] private float meleeAttackCooldown;
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private int numberOfJumps = 1;
    [SerializeField] private float jumpForce = 2f;


    [SerializeField] private BoxCollider2D meleeAttackCollider;

    private bool isAttacking;
    private Vector2 movement;
    private Rigidbody2D rb;
    private PlayerAnimations animations;
    private bool canJump = false;
    private bool isGrounded = true;
    private int jumpsLeft;

    private void Awake() {
        instance = this;
    }

    private void Start()
    {
        isAttacking = false;
        InputManager.input.Player.MeleeAttack.performed += MeleeAttack;
        InputManager.input.Player.RangeAttack.performed += RangeAttack;
        rb = GetComponent<Rigidbody2D>();
        animations = GetComponent<PlayerAnimations>();
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

    void MeleeAttack(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (isAttacking) return;
        isAttacking = true;
        animations.AttackMelee();
        meleeAttackCollider.enabled = true;
        StartCoroutine(Attack(meleeAttackCooldown));
        StartCoroutine(MeleeHitBoxDisable(0.05f));
    }

    void RangeAttack(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (isAttacking) return;
        isAttacking = true;
        animations.AttackRange();
        StartCoroutine(Attack(meleeAttackCooldown));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(meleeDmg + weaponDmg);
        }
    }

    IEnumerator Attack(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isAttacking = false;
    }

    IEnumerator MeleeHitBoxDisable(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        meleeAttackCollider.enabled = false;
    }

    public Vector2 GetMovement() { return movement; }
    public Vector2 GetVelocity() { return rb.velocity; }
    public bool GetIsAttacking() { return isAttacking; }
    public bool GetIsGrounded() {  return isGrounded; }
    public void TakeDamage(float amount) {
        Debug.Log("Dupa: " + amount);
    }

    public Transform GetTransform() {
        return transform;
    }
}
