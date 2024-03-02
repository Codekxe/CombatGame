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
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCanAttack == true)
        {
            anim.SetBool("IsBossAttacking", true);
            isCanAttack = false;
            StartCoroutine(ResetAttack());
        }

    }
    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(0.617f);
        anim.SetBool("IsBossAttacking", false);
        isCanAttack = true;
    }
}
