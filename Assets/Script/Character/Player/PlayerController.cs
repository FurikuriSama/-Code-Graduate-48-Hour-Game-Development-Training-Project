using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    public float moveSpeed;
    private Rigidbody2D rb;
    public float inputDeadzone = 0.1f; // 输入死区，用于过滤非常小的输入值
    Animator animator;
    public bool isDead;

    private Player player; // 引用 Player 类

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // 确保重力不影响俯视视角的玩家
        animator = GetComponent<Animator>();
        player = GetComponent<Player>(); // 获取 Player 组件
    }

    void Update()
    {
        if (isDead)
        {
            SetAnimation(); // 确保在死亡时更新动画
            return; // 如果角色死亡，停止其他输入处理
        }

        ProcessMovement();

        // 检测攻击按键并调用 Attack()
        if (Input.GetButtonDown("Fire1")) // "Fire1" 是 Unity 的默认攻击按键
        {
            Attack(); // 调用 Attack 方法
        }
    }

    void FixedUpdate()
    {
        if (isDead)
            return; // 如果角色死亡，停止移动

        ProcessMovement(); // 使用通用的处理移动方法
    }

    // 移动和动画处理逻辑提取到一个单独方法
    void ProcessMovement()
    {
        // 获取玩家输入
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // 忽略在死区范围内的非常小的输入值
        if (Mathf.Abs(moveX) < inputDeadzone) moveX = 0;
        if (Mathf.Abs(moveY) < inputDeadzone) moveY = 0;

        // 计算移动方向
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        // 更新动画参数
        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
        animator.SetFloat("Speed", moveDirection.magnitude); // 使用 magnitude 来获取向量的长度

        // 应用移动
        rb.velocity = moveDirection * moveSpeed;
    }

    void Attack()
    {
        // 设置攻击动画触发器
        animator.SetTrigger("Attack");

        // 这里可以调用 PerformAttack 方法，检测附近敌人并造成伤害
        PerformAttack(); 
    }

    void PerformAttack()
    {
        // 执行攻击时的逻辑，例如检测攻击范围内的敌人并造成伤害
        Debug.Log("Attacking...");
    }

    public void PlayerHurt() 
    {
        animator.SetTrigger("Hurt"); // 触发受伤动画
    }

    public void PlayerDead()
    {
        isDead = true;
        rb.velocity = Vector2.zero; // 停止移动
        SetAnimation(); // 更新死亡动画
    }

    void SetAnimation()
    {
        animator.SetBool("isDead", isDead); // 设置死亡动画的状态
    }
}
