using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ����׷��״̬
/// </summary>
public class EnemyChaseState : IState
{
    private Enemy enemy;

    //���캯��
    public EnemyChaseState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void OnEnter()
    {
        enemy.animator.Play("Walk");//û��׷������������·����
    }
    public void OnUpdate()
    {
        //�ж��Ƿ�����
        if (enemy.isHurt)
        {
            enemy.TransitionState(EnemyStateType.Hurt);
        }

        enemy.GetPlayerTransform();//��ȡ���λ��

        enemy.AutoPath();//�Զ�Ѱ·

        if (enemy.player != null)
        {
            //�ж�·�����б��Ƿ�Ϊ��
            if (enemy.pathPointList == null || enemy.pathPointList.Count <= 0)
                return;

            //�Ƿ񵽹�����Χ��
            if (enemy.distance <= enemy.attackDistance)//�Ƿ��ڹ�����Χ
            {
                enemy.TransitionState(EnemyStateType.Attack);
            }
            else
            {

                //׷�����
                Vector2 direction = (enemy.pathPointList[enemy.currentIndex] - enemy.transform.position).normalized;
                enemy.MovementInput = direction;//�ƶ����򴫸�MovementInput

            }
        }
        else
        {
            //��Χ���ֹͣ׷�����ص�����״̬
            enemy.TransitionState(EnemyStateType.Idle);
        }
    }

    public void OnFixedUpdate()
    {
        enemy.Move();
    }

    public void OnExit()
    {

    }




}
