using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour
{
    public GameObject shellExplosion;
   
    public void OnTriggerEnter(Collider collider)
    {
        
        GameObject.Instantiate(shellExplosion, transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject);

        if(collider.tag=="tank")
        {
            collider.SendMessage("TankDamage");
        }
        if(collider.tag=="Player")
        {
            collider.SendMessage("Damage");
        }
    }
}
