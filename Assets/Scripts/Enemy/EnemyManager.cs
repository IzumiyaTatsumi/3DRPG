using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyManager : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    Animator animator;
    public Collider weaponCollider;
    public EnemyUIManager enemyUIManager;
    public GameObject gameClearText;
    public GameObject reStartButton;
    public GameObject endButton;
    public int maxhp = 100;
    int hp;

    /// <summary>
    /// �J�n��(Update�O�Ɉ�񂾂����s)
    /// </summary>
    void Start()
    {
        hp = maxhp;
        enemyUIManager.Init(this);

        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
        HideColliderWeapon();
    }

    void Update()
    {
        agent.destination = target.position;
        animator.SetFloat("Distance", agent.remainingDistance);
    }

    // Player�̕��Ɍ�����������
    public void LookAtTarget()
    {
        transform.LookAt(target);
    }

    // ����̔����L���ɂ�����������肷��֐�
    // �~�艺�낵����
    public void HideColliderWeapon()
    {
        weaponCollider.enabled = false;
    }

    // �~�艺�낷�O
    public void ShowColliderWeapon()
    {
        weaponCollider.enabled = true;
    }

    void Damage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            animator.SetTrigger("Die");
            Destroy(gameObject, 2f);//���񂾂���2�b��ɏ���

            // �|������e�L�X�g�ƃ{�^����\��
            gameClearText.SetActive(true);
            reStartButton.SetActive(true);
            endButton.SetActive(true);
        }
        enemyUIManager.UpdateHP(hp);
        //Debug.Log("�G�c��HP:" + hp);
    }

    private void OnTriggerEnter(Collider other)
    {
        // �_���[�W��^������̂ɂԂ�������
        Damager damager = other.GetComponent<Damager>();

        if (damager != null)
        {
            Debug.Log("�G�_���[�W���󂯂�");
            animator.SetTrigger("Hurt");
            Damage(damager.damage);
        }
    }
}
