using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lxs_Tank : lxs_Unit  {

    public float MoveSpeed;
    public float RotateSpeed;

    private lxs_TankWeapon tw;//调用

	// Use this for initialization
	new void  Start () {

        base.Start();

        tw = GetComponent<lxs_TankWeapon>();
        tw.Init(team);
	}
	// Update is called once per frame
	void FixedUpdate () {

        float horizontal = Input.GetAxis("Horizontal");//Edit_Project_setting_input
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime * vertical);
        transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime * horizontal);


        if (Input.GetMouseButtonDown(0))
        {
          tw.Shoot();
         }

        //if(Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(new Vector3(0, 0, 1) * MoveSpeed * Time.deltaTime);
        //    //deltaTime平衡不同性能主机的物体速度,不同性能的主机运行帧数不同
        //}


        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(Vector3.forward*MoveSpeed*Time.deltaTime);
        //    //Translate前进
        //    //Vector3 3维向量
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(Vector3.forward * -MoveSpeed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Rotate(Vector3.up * -RotateSpeed * Time.deltaTime);
        //    //Rotate旋转
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
        //}


    }
}
