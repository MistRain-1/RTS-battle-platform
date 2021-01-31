using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Unit  {

    public float MoveSpeed;
    public float RotateSpeed;

    private TankWeapon tw;//调用

	// Use this for initialization
	new void  Start () {

        base.Start();

        tw = GetComponent<TankWeapon>();
        tw.Init(team);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float horizontal = Input.GetAxis("Horizontal1");//Edit_Project_setting_input
        float vertical = Input.GetAxis("Vertical1");

        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime * vertical);
        transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime * horizontal);


        if (Input.GetMouseButtonDown(0))
        {
          tw.Shoot();
         }
    }
}
