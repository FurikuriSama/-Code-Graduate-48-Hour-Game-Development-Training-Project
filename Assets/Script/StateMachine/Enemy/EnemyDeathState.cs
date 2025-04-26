using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//死亡

public class EnemyDeathState : IState
{
    private Enemy enemy;

    
    public EnemyDeathState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void OnEnter()
    {
        enemy.animator.Play("Die");     
        enemy.rb.velocity = Vector2.zero;       //禁用刚体移动
        enemy.enemyCollider.enabled = false;    //禁用碰撞体
    }
    public void OnUpdate()
    {

    }

    public void OnFixedUpdate()
    {

    }


    public void OnExit()
    {

    }



}
