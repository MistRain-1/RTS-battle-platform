using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime.Tasks;

public class lxs_Attack : Action
{
    public float enemySearchRange;//敌人（可加AI队友）
    public ISRange attackRange;//攻击距离
    public ISRange stoppingDistance;
    public float moveSpeed;
    public float roateSpeed;//转向速度
    public float CoreTimerInterval;//定时器间隔

    private GameObject enemy;
    private NavMeshAgent nam;
    private lxs_TankWeapon tw;
    private LayerMask enemyLayer;

    private float curAR;
    private float curSD;
    public override TaskStatus OnUpdate()
    {
        float dist = Vector3.Distance(enemy.transform.position, transform.position);

        return base.OnUpdate();
    }

    public override void OnStart()
    {
        base.OnStart();

        tw = GetComponent<lxs_TankWeapon>();
        nam = GetComponent<NavMeshAgent>();
    }
}
