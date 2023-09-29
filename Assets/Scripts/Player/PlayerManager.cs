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

    // Update前に一回だけ実行
    void Start()
    {
        hp = maxhp;
        stamina = maxstamina;
        playerUIManager.Init(this);

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        HideColliderWeapon();
    }

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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        // スタミナ自動回復
        IncreaseStamina();
    }

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

    void Attack()
    {
        //Debug.Log("攻撃!!");
        
        // もしスタミナがあったら攻撃
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
        // 敵と一定の距離だったら敵の方に方向を向ける
        float distance = Vector3.Distance(transform.position, target.position);
        if(distance <= 2f)
        {
            transform.LookAt(target);
        }
    }

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
        if(hp <= 0)
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
