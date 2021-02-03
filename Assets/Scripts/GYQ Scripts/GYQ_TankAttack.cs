using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GYQ_TankAttack : MonoBehaviour
{
    public GameObject shell;
    private Transform fireposition;
    public float shellspeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        fireposition = transform.Find("firePosition");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public  void attack()
    {
        GameObject go = GameObject.Instantiate(shell, fireposition.position, fireposition.rotation) as GameObject;
        go.GetComponent<Rigidbody>().velocity = go.transform.forward * shellspeed;
    }
}
