using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GYQ_DestroyForTime : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Destroy(this.gameObject,time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
