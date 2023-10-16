using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackBehaviour : StateMachineBehaviour
{
    /// <summary>
    /// �A�j���[�V�����J�n���ɌĂ΂�鏈��
    /// </summary>
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyManager>().LookAtTarget();
        animator.GetComponent<NavMeshAgent>().speed = 0;
    }

    /// <summary>
    /// �A�j���[�V�����̑J�ڂ��s����Ƃ��ɌĂ΂��(�J�ڌ��ɖ߂�Ƃ�
    /// </summary>
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Hurt");
    }
}
