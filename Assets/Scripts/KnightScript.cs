using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightScript : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float dirX, moveSpeed = 5.0f;
    int healthPoints = 3;
    bool isHurting, isDead, isAttacking;
    bool facingRight = true;
    Vector2 localScale;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isDead && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * 600f);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 10f;
        }
        else
        {
            moveSpeed = 5f;
        }

        SetAnimationState();

        if (!isDead)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
                dirX = rb.velocity.x;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
                dirX = -rb.velocity.x;
            }
        }
    }

    void FixedUpdate()
    {
        if (!isHurting)
            rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void SetAnimationState()
    {
        if (dirX == 0)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }

        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
        }

        if (Mathf.Abs(dirX) == 5 && rb.velocity.y == 0)
            anim.SetBool("isWalking", true);

        if (Mathf.Abs(dirX) == 10 && rb.velocity.y == 0)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

        if (rb.velocity.y > 0)
            anim.SetBool("isJumping", true);

        if (rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
        }
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;

    }

   /* void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Fire"))
        {
            healthPoints -= 1;
        }

        if (col.gameObject.name.Equals("Fire") && healthPoints > 0)
        {
            anim.SetTrigger("isHurting");
            StartCoroutine("Hurt");
        }
        else
        {
            dirX = 0;
            isDead = true;
            anim.SetTrigger("isDead");
        }
    }*/

    IEnumerator Hurt()
    {
        isHurting = true;
        rb.velocity = Vector2.zero;

        if (facingRight)
            rb.AddForce(new Vector2(-200f, 200f));
        else
            rb.AddForce(new Vector2(200f, 200f));

        yield return new WaitForSeconds(0.5f);

        isHurting = false;
    }
}
