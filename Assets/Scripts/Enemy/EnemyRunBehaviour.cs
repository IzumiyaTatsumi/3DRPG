using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRunBehaviour : StateMachineBehaviour
{
    /// <summary>
    /// �A�j���[�V�����J�n���ɌĂ΂�鏈��
    /// </summary>
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<NavMeshAgent>().speed = 2;
    }
}
