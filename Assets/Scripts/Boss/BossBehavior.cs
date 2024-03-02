using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    private Animator anim;
    private bool isCanAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        new WaitForSeconds(5.0f);
        anim.SetBool("IsAttacking", true);
        isCanAttack = false;
        StartCoroutine(ResetAttack());
    }
    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(0.467f);
        anim.SetBool("IsAttacking", false);
        isCanAttack = true;
    }
}
