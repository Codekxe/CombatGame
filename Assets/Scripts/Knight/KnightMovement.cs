using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    public Transform player;

    private bool isFlipped = false;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 15f;
    private bool isCanAttack = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonDown("Fire1") && isCanAttack == true)
        {
            anim.SetBool("IsAttacking", true);
            isCanAttack = false;
            StartCoroutine(ResetAttack());
        }

        UpdateAnimationState();
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(0.467f);
        anim.SetBool("IsAttacking", false);
        isCanAttack = true;
    }
    private void UpdateAnimationState()
    {
        if (dirX > 0f && isFlipped == false)
        {
            anim.SetBool("IsWalking", true);
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
        else if (dirX < 0f && isFlipped == true)
        {
            anim.SetBool("IsWalking", true);
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        if (rb.velocity.y > 0.001f)
        {
            anim.SetBool("IsJumping", true);
        }

        if (rb.velocity.y < 0.001f)
        {
            anim.SetBool("IsJumping", false);
        }
    }
}

