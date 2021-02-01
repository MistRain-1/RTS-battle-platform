using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum lxs_Team// 队伍层级
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
public class lxs_Unit : MonoBehaviour
{

    public int Health = 100;
    public lxs_Team team;
    public GameObject deadEffect;

    public int curHealth;

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
        if (curHealth > damage)
        {
            curHealth -= damage;
        }

        else if (curHealth <= damage)
        { Destruct(); }

    }

    public void Destruct()
    {
        curHealth = 0;

        if (deadEffect != null)
        {
            Instantiate(deadEffect, transform.position, transform.rotation);
        }
        //Destroy(gameObject);
        gameObject.active = false;
        curHealth = 100;
    }

}
