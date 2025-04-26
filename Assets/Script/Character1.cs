using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character1 : MonoBehaviour
{
    [Header("����")]
    [SerializeField]protected float maxHealth;
    [SerializeField]protected float currentHealth;

    [Header("�޵�")]
    public bool invulnerable;
    public float invulnerableDuration;      //�޵�ʱ�䣬��ֹupdate�������౻��ɱ

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
            StartCoroutine(nameof(invulnerableCoroutine));      //�����޵�ʱ��Э��
            //ִ�н�ɫ���˶���
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
        //ִ�н�ɫ��������
        OnDie?.Invoke();
    }

    //�޵�
    protected virtual IEnumerable invulnerableCoroutine()
    {
        invulnerable = true;

        //�޵�ʱ���ָ�Э��ִ��
        yield return new WaitForSeconds(invulnerableDuration);

        invulnerable = false;
    }
}
