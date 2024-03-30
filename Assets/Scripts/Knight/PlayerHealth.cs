using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    public Image HealthBar;
    public TextMeshProUGUI PlayerHealthText;
    public Image Red;
    public Image BossHealthBar;
    public TextMeshProUGUI BossHealthText;
    public Image OtherRed;
    public Image BlackScreen;
    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI RetryText;
    public TextMeshProUGUI WinText;
    public Image Knight;

    public void Start()
    {
        health = maxHealth;
        HealthBar.enabled = true;
        PlayerHealthText.enabled = true;
        Red.enabled = true;
        BossHealthText.enabled = true;
        BossHealthBar.enabled = true;
        OtherRed.enabled = true;
        BlackScreen.enabled = false;
        GameOverText.enabled = false;
        RetryText.enabled = false;
        WinText.enabled = false;
        Knight.enabled = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        StartCoroutine(DamageAnimation());

        if (health <= 0)
        {
            Die();
        }

        HealthBar.fillAmount = Mathf.Clamp((float)health/maxHealth, 0f, 1f);
        PlayerHealthText.text = health.ToString();
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
        HealthBar.enabled = false;
        PlayerHealthText.enabled = false;
        Red.enabled = false;
        BossHealthText.enabled = false;
        BossHealthBar.enabled = false;
        OtherRed.enabled = false;
        BlackScreen.enabled = true;
        GameOverText.enabled = true;
        RetryText.enabled = true;
        WinText.enabled = true;
        Knight.enabled = true;
    }

    IEnumerator DamageAnimation()
    {
        Animator playerAnimator = GameObject.Find("Knight").GetComponent<Animator>();

        playerAnimator.SetBool("IsInvincible", true);
        yield return new WaitForSeconds(1.067f);
        playerAnimator.SetBool("IsInvincible", false);
    }
}
