using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;


public class lxs_patrol:Action
{
    public float MoveSpeed = 10.0f;  //行走速度
    private Vector3 Target;  //目标位置
    public float rotateSpeed = 10.0f; //旋转的速度

    public lxs_wayPoint path; //Path脚本

    private List<Vector3> waypoints; 
    public  override void OnAwake()
    {
        waypoints = new List<Vector3>(); //定义一个waypoint

        for (int i = 0; i < path.WayPotins.Length; i++) //将Path路径的WayPoints全部数组元素存储到waypoints的列表里
        {
            waypoints.Add(path.WayPotins[i].position);
        }
        GetNextPoint();

    }

    public override TaskStatus OnUpdate()
    {
        bool reached = MoveToPoint(Target);
        if (reached)
        {
            Debug.Log("1");
            GetNextPoint();
        }
        //return base.OnUpdate();
        return TaskStatus.Running;
    }

    void GetNextPoint()  //更新下一个waypoint
    {
        if (waypoints.Count > 0)  //如果当前waypoints里的个数大于0的情况下
        {
            Target = waypoints[0];  //Target就为waypoints的第一个元素
            waypoints.RemoveAt(0); //到达目的地后就把当前waypoint列表的第一个元素给删除掉
            //以达到更新Target位置的目的
            //print("路点为：" + waypoints.Count);
        }
    }

    bool MoveToPoint(Vector3 point)  //定义一个布尔类型的移动到目标点的函数
    {
        float distance = Vector3.Distance(this.transform.position, point);

        if (distance < 3f) //如果当前位置与目标位子小于0.15的话，就返回true
        {
            return true;
        }
        //设置当前目标的旋转为目标减去当前位置的方向
        Quaternion wantedRot = Quaternion.LookRotation(point - this.transform.position);
        //this.transform.rotation = wantedRot;
        //控制旋转的插值运算
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, wantedRot, rotateSpeed * Time.deltaTime);


        //移动方向为单位向量
        Vector3 dir = (point - this.transform.position).normalized;
        this.transform.Translate(dir * MoveSpeed * Time.deltaTime, Space.World);
        return false;//不然就默认返回false
    }
}
