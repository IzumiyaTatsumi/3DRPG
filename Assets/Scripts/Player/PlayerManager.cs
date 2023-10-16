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

    /// <summary>
    /// 開始時(Update前に一回だけ実行)
    /// </summary>
    void Start()
    {
        hp = maxhp;
        stamina = maxstamina;
        playerUIManager.Init(this);

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        HideColliderWeapon();
    }

    /// <summary>
    /// 更新時処理
    /// </summary>
    // 約0.02秒に一回実行
    void Update()
    {
        // 死んでいたら入力を受け付けない
        if (isDie)
        {
            return;
        }

        // キーボード入力移動(横x縦z
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        // 攻撃入力
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        // スタミナ自動回復
        IncreaseStamina();
    }

    /// <summary>
    /// 更新時処理
    /// </summary>
    void IncreaseStamina()
    {
        // スタミナ自動回復
        stamina++;
        if (stamina >= maxstamina)
        {
            stamina = maxstamina;
        }
        playerUIManager.UpdateStamina(stamina);
    }

    /// <summary>
    /// 攻撃時処理
    /// </summary>
    void Attack()
    {
        //Debug.Log("攻撃!!");

        // もしスタミナがあったら攻撃
        if (stamina >= 90)
        {
            stamina -= 90;
            playerUIManager.UpdateStamina(stamina);

            LookAtTarget();
            animator.SetTrigger("Attack");
        }
    }

    /// <summary>
    /// 相手の方に体を向ける処理
    /// </summary>
    void LookAtTarget()
    {
        // 敵と一定の距離だったら敵の方に方向を向ける
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= 2f)
        {
            transform.LookAt(target);
        }
    }

    /// <summary>
    /// 一定時間毎に更新処理
    /// </summary>
    private void FixedUpdate()
    {
        // 死んでいたら入力を受け付けない
        if (isDie)
        {
            return;
        }

        // 自身のpositionから移動した方向へ向きを変える
        Vector3 direction = transform.position + new Vector3(x, 0, z) * moveSpeed;
        transform.LookAt(direction);

        // 速度設定
        rb.velocity = new Vector3(x, 0, z) * moveSpeed;

        // Floatの変数Speedにキー入力された値を設定
        animator.SetFloat("Speed", rb.velocity.magnitude);
    }

    /// <summary>
    /// 武器降り下ろし後処理
    /// </summary>
    public void HideColliderWeapon()
    {
        // 武器判定無効
        weaponCollider.enabled = false;
    }

    /// <summary>
    /// 武器降り下ろし前処理
    /// </summary>
    public void ShowColliderWeapon()
    {
        // 武器判定有効
        weaponCollider.enabled = true;
    }

    /// <summary>
    /// ダメージ計算時処理
    /// </summary>
    void Damage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            isDie = true;
            animator.SetTrigger("Die");

            // 死んだらテキストとボタンを表示
            gameOverText.SetActive(true);
            reStartButton.SetActive(true);
            endButton.SetActive(true);
            rb.velocity = Vector3.zero;
        }
        playerUIManager.UpdateHP(hp);
        //Debug.Log("残りHP:" + hp);
    }

    /// <summary>
    /// 当たり判定処理
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        // 死んでいたらダメージを受けない
        if (isDie)
        {
            return;
        }

        // ダメージを与えるものにぶつかったら
        Damager damager = other.GetComponent<Damager>();

        if (damager != null)
        {
            //Debug.Log("プレイヤーダメージを受ける");
            animator.SetTrigger("Hurt");
            Damage(damager.damage);
        }
    }
}
