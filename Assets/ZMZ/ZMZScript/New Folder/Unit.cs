using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team// 队伍层级
{
    lxs,
    fk,
    gyq,
    whl,
    hhy,
    hyf,
    ywj,
    zmz
}

public class Unit:MonoBehaviour
{

    public int Health = 100;
    public Team team;
    public GameObject deadEffect;

    private int curHealth;

    public int GetcurHealth()
    {
        return curHealth;
    }

    public void Start()
    {
        curHealth = Health;
    }

    public void ApplyDamage(int damage)
    {
       if(curHealth>damage)
        {
            zmz_Attack.enemyhealthy -= damage;
            curHealth -= damage;
        }
       else
        Destruct();
    }

    public void Destruct()
    {
        curHealth = 0;

        if(deadEffect!=null)
        {
            GameObject.Instantiate(deadEffect, transform.position, transform.rotation);
        }
        GameObject.Destroy(gameObject);
    }

  
}
