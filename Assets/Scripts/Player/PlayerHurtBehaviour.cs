using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    // アニメーション開始時に呼ばれる
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Hurt");

        // 速度を0にする
        animator.GetComponent<PlayerManager>().moveSpeed = 0.4f;

        // 攻撃を食らった時に剣のあたり判定を無くしておく
        animator.GetComponent<PlayerManager>().HideColliderWeapon();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    // アニメーション中に実行される
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // アニメーションの遷移が行われるときに呼ばれる(遷移元に戻るとき
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Hurt");

        // 速度を元に戻す
        animator.GetComponent<PlayerManager>().moveSpeed = 3;
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
