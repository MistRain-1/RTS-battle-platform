using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lxs_Default : MonoBehaviour {

     void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name=="ground")
        {
            Destroy(this.gameObject);
        }
    }


}
