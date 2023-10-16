using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBehaviour : StateMachineBehaviour
{
    /// <summary>
    /// アニメーション開始時に呼ばれる処理
    /// </summary>
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Hurt");

        // 速度を0にする
        animator.GetComponent<PlayerManager>().moveSpeed = 0.4f;

        // 攻撃を食らった時に剣のあたり判定を無くしておく
        animator.GetComponent<PlayerManager>().HideColliderWeapon();
    }

    /// <summary>
    /// アニメーション中に実行される
    /// </summary>
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    /// <summary>
    /// アニメーションの遷移が行われるときに呼ばれる(遷移元に戻るとき
    /// </summary>
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Hurt");

        // 速度を元に戻す
        animator.GetComponent<PlayerManager>().moveSpeed = 3;
    }
}
