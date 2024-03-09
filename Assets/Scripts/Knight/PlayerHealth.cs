using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public void TakeDamage(int damage)
    {
        health -= damage;

        StartCoroutine(DamageAnimation());

        if (health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        StartCoroutine(EndGameEffect());
    }

    IEnumerator EndGameEffect()
    {
        Animator playerAnimator = GameObject.Find("Knight").GetComponent<Animator>();
        Animator bossAnimator = GameObject.Find("Boss").GetComponent<Animator>();

        playerAnimator.SetBool("IsDead", true);
        yield return new WaitForSeconds(0.467f);
        playerAnimator.enabled = false;
    }

    IEnumerator DamageAnimation()
    {
        Animator playerAnimator = GameObject.Find("Knight").GetComponent<Animator>();

        playerAnimator.SetBool("IsHurting", true);
        yield return new WaitForSeconds(0.467f);
        playerAnimator.SetBool("IsHurting", false);
    }
}
