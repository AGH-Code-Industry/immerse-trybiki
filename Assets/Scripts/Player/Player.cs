using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHp;
    [SerializeField] private int meleeDmg;
    [SerializeField] private int weaponDmg;
    [SerializeField] private float meleeAttackCooldown;
    [SerializeField] private float movementSpeed;

    [SerializeField] private BoxCollider2D meleeAttackCollider;

    private bool isAttacking;
    private Animator animator;
    private Vector2 movement;
    private Rigidbody2D rb;

    private void Start()
    {
        isAttacking = false;
        InputManager.input.Player.MeleeAttack.performed += MeleeAttack;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        movement = InputManager.navigationAxis;
        rb.velocity = new Vector2(-movement.x * movementSpeed * Time.deltaTime * 100, rb.velocity.y);
    }

    void MeleeAttack(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (isAttacking) return;
        isAttacking = true;
        meleeAttackCollider.enabled = true;
        StartCoroutine(Attack(meleeAttackCooldown));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(meleeDmg + weaponDmg);
        }
        Debug.Log("hit");
    }

    IEnumerator Attack(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isAttacking = false;
        meleeAttackCollider.enabled = false;
        animator.SetBool("isAttacking", false);
    }

    public Vector2 GetMovement() { return movement; }
    public bool GetIsAttacking() { return isAttacking; }
}
