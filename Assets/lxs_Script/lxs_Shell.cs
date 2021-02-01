using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lxs_Shell : MonoBehaviour {

    public int damage;
    public float explosionnForce;
    public float explosionRadius;
    public GameObject explosionEffect;
    public float explosionTimeUp;//时间延迟，爆炸后销毁

    public LayerMask lm;

    public void Init(LayerMask enemyLayer)
    {
        lm = enemyLayer;
    }

    void OnCollisionEnter()
    {
        GameObject obj = Instantiate(explosionEffect, transform.position, transform.rotation) as GameObject;//转换类型
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

                lxs_Unit u = cols[i].GetComponent<lxs_Unit>();
                if (u!= null)
                {
                    Debug.Log("血量扣除");
                    u.ApplyDamage(damage); 
                }
                    

            }
        }
        
    }
}
