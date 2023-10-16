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
    /// 開始時(Update前に一回だけ実行)
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

    // Playerの方に向きを向ける
    public void LookAtTarget()
    {
        transform.LookAt(target);
    }

    // 武器の判定を有効にしたり消したりする関数
    // 降り下ろした後
    public void HideColliderWeapon()
    {
        weaponCollider.enabled = false;
    }

    // 降り下ろす前
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
            Destroy(gameObject, 2f);//死んだあと2秒後に消す

            // 倒したらテキストとボタンを表示
            gameClearText.SetActive(true);
            reStartButton.SetActive(true);
            endButton.SetActive(true);
        }
        enemyUIManager.UpdateHP(hp);
        //Debug.Log("敵残りHP:" + hp);
    }

    private void OnTriggerEnter(Collider other)
    {
        // ダメージを与えるものにぶつかったら
        Damager damager = other.GetComponent<Damager>();

        if (damager != null)
        {
            Debug.Log("敵ダメージを受ける");
            animator.SetTrigger("Hurt");
            Damage(damager.damage);
        }
    }
}
