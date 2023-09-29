using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    // �A�j���[�V�����J�n���ɌĂ΂��
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Hurt");

        // ���x��0�ɂ���
        animator.GetComponent<PlayerManager>().moveSpeed = 0.4f;

        // �U����H��������Ɍ��̂����蔻��𖳂����Ă���
        animator.GetComponent<PlayerManager>().HideColliderWeapon();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    // �A�j���[�V�������Ɏ��s�����
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // �A�j���[�V�����̑J�ڂ��s����Ƃ��ɌĂ΂��(�J�ڌ��ɖ߂�Ƃ�
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Hurt");

        // ���x�����ɖ߂�
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
