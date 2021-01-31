using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AITank:Unit
{
    public  float enemySearchRange;//敌人（可加AI队友）
    public ISRange attackRange;//攻击距离
    public ISRange stoppingDistance;
    public float moveSpeed;
    public float roateSpeed;//转向速度
    public float CoreTimerInterval;//定时器间隔


    private GameObject enemy;
    private NavMeshAgent nam;//需烘焙AI寻路地图，坦克组件增加 nav agent
    private TankWeapon tw;
    private LayerMask enemyLayer;

    private float curAR;
    private float curSD;

    new void Start()
    {
        base.Start();
       
        tw = GetComponent<TankWeapon>();
        nam = GetComponent<NavMeshAgent>();

        enemyLayer = LayerManager.GetEnemyLayer(team);
        tw.Init(team);//队伍伤害

        //StartCoroutine(Timer());//调用协程
    }

    void FixedUpdate()//修复敌人“日墙”fixedUpdate
    {
        if(enemy==null)//寻找敌人
        {
            SearchEnemy();
            return;
        }

        float dist = Vector3.Distance(enemy.transform.position, transform.position);

        

        if(dist>curSD)//不同的AI攻击距离不同
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

        if(dist<curAR)
        {
            tw.Shoot();
        }
    }


    //IEnumerator Timer()
    //{
        
    //    //while(GameObject.enabled)
    //    //{
    //    //    curAR = ISMath.Randon(attackRange);//攻击最近距离
    //    //    curSD = ISMath.Randon(stoppingDistance);
    //    //    curSD = Mathf.Min(curAR, curSD);//避免随机数太大
    //    //    SearchEnemy();

    //    //    yield return new WaitForSeconds(CoreTimerInterval);
    //    //}
    //}

    public void SearchEnemy()//寻找最近敌人的算法  参考设置碰撞器之间的距离，间距不为零时，让自身坦克朝向敌人军队前进，且需考虑 停止距离（因为坦克会在距提防坦克一定间距射击）
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange.max, 1 << LayerMask.NameToLayer("Enemys"));

        if(colliders.Length <= 0)
            return;

        //for (int i = 0; i < colliders.Length; i++)
        //    print(colliders[i].gameObject.name);
    }
}
