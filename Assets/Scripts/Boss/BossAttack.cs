using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public int attackDamage = 10;
    public int enragedAttackDamage = 20;

    public Vector3 attackOffset;
    public float attackRange = 3.7f;
    public LayerMask attackMask;

    public void Attack()
    {
        Vector3 pos = transform.position;
        /*pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;*/

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        Debug.Log(colInfo);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }
}
