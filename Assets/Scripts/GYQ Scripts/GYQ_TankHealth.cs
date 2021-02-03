using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GYQ_TankHealth : MonoBehaviour
{
    public int hp = 100;
  
    public GameObject tankExplosion;
    public bool isHurt=false;
  
    
    void TankDamage()
    {
        if (hp <= 0) return;
        hp -= Random.Range(5, 10);
       
        if(hp<=0)
        {          
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }

   void Damage()
    {
        if (hp <= 0) return;
        hp -= Random.Range(2, 5);
        if(hp>=70&&hp<=80)
        {
            isHurt = true;
        }
        if (hp <= 0)
        {
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }
}
