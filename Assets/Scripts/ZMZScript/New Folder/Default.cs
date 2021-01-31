using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default : MonoBehaviour {

     void OnCollisionEnter(Collision collision)//子弹碰撞地面
    {
        if(collision.gameObject.name=="ground")
        {
            Destroy(this.gameObject);
        }
    }


}
