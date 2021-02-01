using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class lxs_AITank : lxs_Unit
{
    public  float enemySearchRange;//敌人（可加AI队友）
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
    public enum FSMstate
    {
        None,
        Patrol,
        Search,
        Attack
    }
    public FSMstate curState;

    new void Start()
    {
        base.Start();
       
        tw = GetComponent<lxs_TankWeapon>();
        nam = GetComponent<NavMeshAgent>();

        enemyLayer = lxs_LayerManager.GetEnemyLayer(team);
        tw.Init(team);//队伍伤害

        StartCoroutine(Timer());//调用协程

        //curState = FSMstate.Patrol;
    }

    void FixedUpdate()//修复敌人“日墙”fixedUpdate
    {
        switch (curState)
        {
            case FSMstate.Patrol:
                StatePatrol();
                break;
            case FSMstate.Search:
                StateSearch();
                break;
            case FSMstate.Attack:
                StateAttack();
                break;
        }

        if (enemy == null)//寻找敌人
        {
            //SearchEnemy();
            Collider[] cols = Physics.OverlapSphere(transform.position, enemySearchRange, enemyLayer);
            if (cols.Length > 0)//判断碰撞器
            {
                float curMinDist = Mathf.Infinity;//无尽
                for (int i = 0; i < cols.Length; i++)
                {
                    float curDist = Vector3.Distance(transform.position, cols[i].transform.position);
                    if (curDist < curMinDist)
                    {
                        curMinDist = curDist;
                        enemy = cols[i].gameObject;
                    }
                }
            }
            return;
        }

        float dist = Vector3.Distance(enemy.transform.position, transform.position);
        //Debug.Log(dist);

        //if (dist > curSD)//重新计算路径
        //{
        //    nam.SetDestination(enemy.transform.position);
        //}
        //else
        //{

        //    nam.ResetPath();
        //    Vector3 dir = enemy.transform.position - transform.position;//LookAt
        //    Quaternion wantedRotation = Quaternion.LookRotation(dir);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, roateSpeed * Time.deltaTime);//插值，计算过度效果 旋转
        //}

        if (dist < curAR)
        {
            //Debug.Log("0");
            tw.Shoot();
        }

        //void Update()
        //{
        //    switch (curState)
        //    {
        //        case FSMstate.Patrol:
        //            StatePatrol();
        //            break;
        //        case FSMstate.Search:
        //            StateSearch();
        //            break;
        //        case FSMstate.Attack:
        //            StateAttack();
        //            break;
        //    }
        //}
    }


    IEnumerator Timer()
    {
        while(enabled)
        {
            curAR = lxs_ISMath.Randon(attackRange);//攻击最近距离
            curSD = lxs_ISMath.Randon(stoppingDistance);
            curSD = Mathf.Min(curAR, curSD);//避免随机数太大
            //SearchEnemy();

            yield return new WaitForSeconds(CoreTimerInterval);
        }
    }

    public void SearchEnemy()//寻找最近敌人的算法
    {
        Collider[] cols = Physics.OverlapSphere(transform.position,enemySearchRange, enemyLayer);
        if(cols.Length>0)//判断碰撞器
        {
            float curMinDist = Mathf.Infinity;//无尽
            for(int i=0;i<cols.Length;i++)
            {
                float curDist = Vector3.Distance(transform.position, cols[i].transform.position);
                if(curDist<curMinDist)
                {
                    curMinDist = curDist;
                    enemy = cols[i].gameObject;
                }
            }
        }
       
    }

    void StatePatrol()//巡逻
    {
        Debug.Log("2");
        float dist = Vector3.Distance(enemy.transform.position, transform.position);

        if (dist > curSD)//不同的AI攻击距离不同
        {
            nam.SetDestination(enemy.transform.position);
        }
        else
        {
            nam.ResetPath();
            Vector3 dir = enemy.transform.position - transform.position;//LookAt
            Quaternion wantedRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, roateSpeed * Time.deltaTime);//插值，计算过度效果 旋转
        }
    }
    void StateSearch()//搜寻
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, enemySearchRange, enemyLayer);
        if (cols.Length > 0)//判断碰撞器
        {
            float curMinDist = Mathf.Infinity;//无尽
            for (int i = 0; i < cols.Length; i++)
            {
                float curDist = Vector3.Distance(transform.position, cols[i].transform.position);
                if (curDist < curMinDist)
                {
                    curMinDist = curDist;
                    enemy = cols[i].gameObject;
                    Debug.Log("1");
                }
            }
        }
    }
    void StateAttack()//攻击
    {
        float dist = Vector3.Distance(enemy.transform.position, transform.position);
        if (dist < curAR)
        {
            tw.Shoot();
        }
    }
}
