using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBehaviour : StateMachineBehaviour
{
    /// <summary>
    /// �A�j���[�V�����J�n���ɌĂ΂�鏈��
    /// </summary>
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Hurt");

        // ���x��0�ɂ���
        animator.GetComponent<PlayerManager>().moveSpeed = 0.4f;

        // �U����H��������Ɍ��̂����蔻��𖳂����Ă���
        animator.GetComponent<PlayerManager>().HideColliderWeapon();
    }

    /// <summary>
    /// �A�j���[�V�������Ɏ��s�����
    /// </summary>
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    /// <summary>
    /// �A�j���[�V�����̑J�ڂ��s����Ƃ��ɌĂ΂��(�J�ڌ��ɖ߂�Ƃ�
    /// </summary>
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Hurt");

        // ���x�����ɖ߂�
        animator.GetComponent<PlayerManager>().moveSpeed = 3;
    }
}
