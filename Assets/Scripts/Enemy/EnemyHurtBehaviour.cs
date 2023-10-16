using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHurtBehaviour : StateMachineBehaviour
{
    /// <summary>
    /// アニメーション開始時に呼ばれる処理
    /// </summary>
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Hurt");
        animator.GetComponent<NavMeshAgent>().speed = 0;
    }

    /// <summary>
    /// アニメーションの遷移が行われるときに呼ばれる(遷移元に戻るとき
    /// </summary>
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Hurt");
    }
}
