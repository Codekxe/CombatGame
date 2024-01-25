using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 10f;

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

        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            anim.SetBool("IsWalking", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("IsWalking", true);
            sprite.flipX = true;
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

