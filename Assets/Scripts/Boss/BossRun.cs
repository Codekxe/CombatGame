using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRun : StateMachineBehaviour
{
    public float speed = 5.0f;
    public float attackRange = 3.5f;

    Transform player;
    Rigidbody2D rb;
    Boss boss;
    PlayerHealth playerHealth;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        if (playerHealth.health > 0)
        {
            rb.MovePosition(newPos);
        }
        /*Debug.Log("Distance" + Vector2.Distance(player.position, rb.position).ToString());*/
        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            BossAttack bossAttack = boss.GetComponent<BossAttack>();
            bossAttack.Attack();
        }
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("IsAttacking");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
