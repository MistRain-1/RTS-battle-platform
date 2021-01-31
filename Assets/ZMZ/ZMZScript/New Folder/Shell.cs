using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

    public int damage;//伤害
    public float explosionnForce;//爆炸力度
    public float explosionRadius;//爆炸范围
    public GameObject explosionEffect;//爆炸效果
    public float explosionTimeUp;//时间延迟，爆炸后销毁

    public LayerMask lm;//层级

    public void Init(LayerMask enemyLayer)
    {
        lm = enemyLayer;
    }

    void OnCollisionEnter()
    {
        GameObject obj = Instantiate(explosionEffect, transform.position, transform.rotation);//转换类型
        Destroy(gameObject);
        Destroy(obj, explosionTimeUp);//定时销毁


        Collider[] cols = Physics.OverlapSphere(transform.position,explosionRadius,lm);//碰撞数组，仅销毁敌人

        if(cols.Length>0)//碰到东西
        {
            for (int i = 0; i < cols.Length; i++)
            {
                Rigidbody r = cols[i].GetComponent<Rigidbody>();

                if (r!=null)
                {
                    r.AddExplosionForce(explosionnForce, transform.position, explosionRadius);
                }

                Unit u = cols[i].GetComponent<Unit>();

                if (u != null)
                    u.ApplyDamage(damage);
            }
        }
        
    }
}
