using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//受伤

public class EnemyHurtState : IState
{
    private Enemy enemy;

    private Vector2 direction;  //击退方向

    private float Timer;        //计时器
    
    public EnemyHurtState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void OnEnter()
    {
        enemy.animator.Play("Hurt");
    }
    public void OnUpdate()
    {
        //是否可以击退
        if (enemy.isKnokback)
        {
            if (enemy.player != null)
            {
                direction = (enemy.transform.position - enemy.player.position).normalized;
            }
            else
            {
                //若在追击范围外player为null
                Transform player = GameObject.FindWithTag("Player").transform;
                direction = (enemy.transform.position - player.position).normalized;
            }
        }

    }

    public void OnFixedUpdate()
    {
        //击退效果
        if (Timer <= enemy.knokbackForceDuration)
        {
            enemy.rb.AddForce(direction * enemy.knokbackForce, ForceMode2D.Impulse);
            Timer += Time.fixedDeltaTime;
        }
        else
        {
            Timer = 0;
            enemy.isHurt = false;
            //待机
            enemy.TransitionState(EnemyStateType.Idle);
        }
    }



    public void OnExit()
    {
        enemy.isHurt = false;
    }


}
