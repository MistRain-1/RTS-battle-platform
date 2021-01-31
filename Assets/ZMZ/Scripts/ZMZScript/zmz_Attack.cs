using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zmz_Attack :Action
{ 
    public GameObject Shell;//子弹预制体
    public float ShootPower;//射击力度
    public Transform ShootPoint;//发射点
    public float ShootCoolDowm;//炮弹冷却时间
    float curShootTime;
    private AudioSource AudioSource;//射击音效
    public LayerMask enemyLayer;
    private bool isWeaponReady = true;//子弹冷却
    public SharedGameObject target;
    public static int enemyhealthy;
    bool findenemy = false;
    // Use this for initialization
    public override void OnAwake()
    {

        curShootTime = ShootCoolDowm;
    }
    public override TaskStatus OnUpdate()
    {
        if (target == null)
        {
            return TaskStatus.Failure;
        }
        if (!findenemy)
        {
            enemyhealthy = target.Value.transform.GetComponent<Unit>().GetcurHealth();
            findenemy = true;
        }
        if (enemyhealthy <= 0)
        {

            target = null;
            return TaskStatus.Success;
           
        }
        transform.LookAt(target.Value.transform.position);
        curShootTime -= Time.deltaTime;
        if (curShootTime <= 0)
        {
            Shoot();
            curShootTime = ShootCoolDowm;
        }
        return TaskStatus.Running;
    }
    public override void OnReset()
    {
        base.OnReset();
    }
    //public void Init(Team team)
    //{
    //    enemyLayer = LayerManager.GetEnemyLayer(team);
    //}
    public void Shoot()
    {
        //if (!isWeaponReady) return;

        GameObject newShell = GameObject.Instantiate(Shell, ShootPoint.position, ShootPoint.rotation);
        Rigidbody r = newShell.GetComponent<Rigidbody>();
        r.velocity = ShootPoint.forward * ShootPower;//方向
        //AudioSource.Play();
        //isWeaponReady = false;
        //StartCoroutine(WeaponCooldown());
    }

    IEnumerator WeaponCooldown()//协程，子弹冷却时间
    {
        yield return new WaitForSeconds(ShootCoolDowm);//定时器，射击
        isWeaponReady = true;
    }
}
