using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health = 100;
    public void TakeDamage(int damage)
    {
        health -= damage;

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
        Animator bossAnimator = GameObject.Find("Boss").GetComponent<Animator>();
        BossAttack attackScript = bossAnimator.GetComponent<BossAttack>();
        Boss flipScript = bossAnimator.GetComponent<Boss>();
        Animator playerAnimator = GameObject.Find("Knight").GetComponent<Animator>();
        KnightScript script = playerAnimator.GetComponent<KnightScript>();

        bossAnimator.SetBool("IsDead", true);
        yield return new WaitForSeconds(0.467f);
        bossAnimator.enabled = false;
        attackScript.enabled = false;
        flipScript.enabled = false;
        script.enabled = false;
        playerAnimator.enabled = false;
    }
}
