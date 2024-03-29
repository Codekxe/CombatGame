using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 300;
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
        BossAttack attackScript = bossAnimator.GetComponent<BossAttack>();
        Boss flipScript = bossAnimator.GetComponent<Boss>();
        KnightScript script = playerAnimator.GetComponent<KnightScript>();

        playerAnimator.SetBool("IsInvincible", false);
        playerAnimator.SetBool("IsDead", true);
        yield return new WaitForSeconds(0.467f);
        bossAnimator.enabled = false;
        attackScript.enabled = false;
        flipScript.enabled = false;
        playerAnimator.enabled = false;
        script.enabled = false;
    }

    IEnumerator DamageAnimation()
    {
        Animator playerAnimator = GameObject.Find("Knight").GetComponent<Animator>();

        playerAnimator.SetBool("IsInvincible", true);
        yield return new WaitForSeconds(1.067f);
        playerAnimator.SetBool("IsInvincible", false);
    }
}
