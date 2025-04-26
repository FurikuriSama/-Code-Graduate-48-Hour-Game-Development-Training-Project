using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//攻击

public class EnemyAttackState : IState
{
    private Enemy enemy;

    private AnimatorStateInfo info;
    

    public EnemyAttackState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void OnEnter()
    {
        if (enemy.isAttack)
        {
            enemy.animator.Play("Attack");
            enemy.isAttack = false;
            enemy.AttackColdown();
        }

    }
    public void OnUpdate()
    {
        //是否受伤
        if (enemy.isHurt)
        {
            enemy.TransitionState(EnemyStateType.Hurt);
        }

        //禁止移动
        enemy.rb.velocity = Vector2.zero;
        //翻转
        float x = enemy.player.position.x - enemy.transform.position.x;
        if (x > 0)
        {
            enemy.sr.flipX = true;
        }
        else
        {
            enemy.sr.flipX = false;
        }
        //获取角色当前播放的状态的信息
        info = enemy.animator.GetCurrentAnimatorStateInfo(0);


        if (info.normalizedTime >= 1f)  //播放完毕切换待机动画
        {
            Debug.Log("触发" + info.normalizedTime);
            enemy.TransitionState(EnemyStateType.Idle);
        }
    }

    public void OnFixedUpdate()
    {

    }


    public void OnExit()
    {

    }



}
