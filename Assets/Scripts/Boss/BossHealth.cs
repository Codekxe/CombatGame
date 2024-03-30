using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int health = 200;
    public Image HealthBar;
    public TextMeshProUGUI BossHealthText;
    public Image Red;
    public Image PlayerHealthBar;
    public TextMeshProUGUI PlayerHealthText;
    public Image OtherRed;
    public Image BlackScreen;
    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI RetryText;
    public TextMeshProUGUI LoseText;
    public Image Troll;

    public void Start()
    {
        health = maxHealth;
        PlayerHealthBar.enabled = true;
        PlayerHealthText.enabled = true;
        Red.enabled = true;
        BossHealthText.enabled = true;
        HealthBar.enabled = true;
        OtherRed.enabled = true;
        BlackScreen.enabled = false;
        GameOverText.enabled = false;
        RetryText.enabled = false;
        LoseText.enabled = false;
        Troll.enabled = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }

        HealthBar.fillAmount = Mathf.Clamp((float)health / maxHealth, 0f, 1f);
        BossHealthText.text = health.ToString();
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
        HealthBar.enabled = false;
        BossHealthText.enabled = false;
        Red.enabled = false;
        PlayerHealthText.enabled = false;
        PlayerHealthBar.enabled = false;
        OtherRed.enabled = false;
        BlackScreen.enabled = true;
        GameOverText.enabled = true;
        RetryText.enabled = true;
        LoseText.enabled = true;
        Troll.enabled = true;
    }
}
