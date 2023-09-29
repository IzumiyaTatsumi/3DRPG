using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    float x;
    float z;
    public float moveSpeed;
    public Collider weaponCollider;
    public PlayerUIManager playerUIManager;
    public GameObject gameOverText;
    public GameObject reStartButton;
    public GameObject endButton;
    public Transform target;
    public int maxhp = 100;
    int hp;
    public int maxstamina = 100;
    int stamina;
    bool isDie = false;

    Rigidbody rb;
    Animator animator;

    // Update�O�Ɉ�񂾂����s
    void Start()
    {
        hp = maxhp;
        stamina = maxstamina;
        playerUIManager.Init(this);

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        HideColliderWeapon();
    }

    // ��0.02�b�Ɉ����s
    void Update()
    {
        // ����ł�������͂��󂯕t���Ȃ�
        if (isDie)
        {
            return;
        }

        // �L�[�{�[�h���͈ړ�(��x�cz
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        
        // �U������
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        // �X�^�~�i������
        IncreaseStamina();
    }

    void IncreaseStamina()
    {
        // �X�^�~�i������
        stamina++;
        if (stamina >= maxstamina)
        {
            stamina = maxstamina;
        }
        playerUIManager.UpdateStamina(stamina);
    }

    void Attack()
    {
        //Debug.Log("�U��!!");
        
        // �����X�^�~�i����������U��
        if(stamina >= 90)
        {
            stamina -= 90;
            playerUIManager.UpdateStamina(stamina);

            LookAtTarget();
            animator.SetTrigger("Attack");
        }
    }

    void LookAtTarget()
    {
        // �G�ƈ��̋�����������G�̕��ɕ�����������
        float distance = Vector3.Distance(transform.position, target.position);
        if(distance <= 2f)
        {
            transform.LookAt(target);
        }
    }

    private void FixedUpdate()
    {
        // ����ł�������͂��󂯕t���Ȃ�
        if (isDie)
        {
            return;
        }

        // ���g��position����ړ����������֌�����ς���
        Vector3 direction = transform.position + new Vector3(x, 0, z) * moveSpeed;
        transform.LookAt(direction);

        // ���x�ݒ�
        rb.velocity = new Vector3(x, 0, z) * moveSpeed;

        // Float�̕ϐ�Speed�ɃL�[���͂��ꂽ�l��ݒ�
        animator.SetFloat("Speed", rb.velocity.magnitude);
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
        if(hp <= 0)
        {
            hp = 0;
            isDie = true;
            animator.SetTrigger("Die");

            // ���񂾂�e�L�X�g�ƃ{�^����\��
            gameOverText.SetActive(true);
            reStartButton.SetActive(true);
            endButton.SetActive(true);
            rb.velocity = Vector3.zero;
        }
        playerUIManager.UpdateHP(hp);
        //Debug.Log("�c��HP:" + hp);
    }

    private void OnTriggerEnter(Collider other)
    {
        // ����ł�����_���[�W���󂯂Ȃ�
        if (isDie)
        {
            return;
        }

        // �_���[�W��^������̂ɂԂ�������
        Damager damager = other.GetComponent<Damager>();

        if (damager != null)
        {
            //Debug.Log("�v���C���[�_���[�W���󂯂�");
            animator.SetTrigger("Hurt");
            Damage(damager.damage);
        }
    }
}
