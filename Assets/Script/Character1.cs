using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character1 : MonoBehaviour
{
    [Header("属性")]
    [SerializeField]protected float maxHealth;
    [SerializeField]protected float currentHealth;

    [Header("无敌")]
    public bool invulnerable;
    public float invulnerableDuration;      //无敌时间，防止update次数过多被秒杀

    public UnityEvent OnHurt;
    public UnityEvent OnDie;

    protected virtual void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        if (invulnerable)
        {
            return;
        }

        if (currentHealth - damage > 0f)
        {
            currentHealth -= damage;
            StartCoroutine(nameof(invulnerableCoroutine));      //启动无敌时间协程
            //执行角色受伤动画
            OnHurt?.Invoke();
        }
        else
        {
            Die();
        }

    }

    public virtual void Die()
    {
        currentHealth = 0f;
        //执行角色死亡动画
        OnDie?.Invoke();
    }

    //无敌
    protected virtual IEnumerable invulnerableCoroutine()
    {
        invulnerable = true;

        //无敌时间后恢复协程执行
        yield return new WaitForSeconds(invulnerableDuration);

        invulnerable = false;
    }
}
