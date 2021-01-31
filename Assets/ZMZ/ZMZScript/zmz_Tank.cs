using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zmz_Tank : MonoBehaviour
{
    // Start is called before the first frame update
    public float movespeed;
    public GameObject bullet,attackpoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Move(1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(2);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Move(3);
        }
    }
   
    public void Move(int i)
    {
        if (i == 0)
        {
            transform.position += movespeed * Time.deltaTime * transform.forward;
        }
        if (i == 1)
        {
            transform.position += -movespeed * Time.deltaTime * transform.forward;
        }
        if (i == 2)
        {
            transform.position += -movespeed * Time.deltaTime * transform.right;
        }
        if (i == 3)
        {
            transform.position += movespeed * Time.deltaTime * transform.right;
        }
    }
    public void Shoot()
    {
        GameObject.Instantiate(bullet, attackpoint.transform.position, attackpoint.transform.rotation);

    }
}
