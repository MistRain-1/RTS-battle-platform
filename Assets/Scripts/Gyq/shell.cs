using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour
{
    public GameObject shellExplosion;
   
    public void OnTriggerEnter(Collider collider)
    {
        
         GameObject go = GameObject.Instantiate(shellExplosion, transform.position, transform.rotation);       
         GameObject.Destroy(this.gameObject);
         GameObject.Destroy(go);


       
        if(collider.tag=="Player")
        {
            collider.SendMessage("Damage");
        }
    }
}
