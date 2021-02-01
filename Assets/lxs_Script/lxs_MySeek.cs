using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class lxs_MySeek : Action
{
    public float speed;
    public Transform target;
    public float arriveDistance = 0.1f;
    private float sqlArrivDistance;

    public override void OnStart()
    {
        sqlArrivDistance = arriveDistance * arriveDistance;
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        if(target==null)
        {
            return TaskStatus.Failure;
        }

        transform.LookAt(target.position);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if((target.position-transform.position).sqrMagnitude<sqlArrivDistance)
        {
            return TaskStatus.Success;
        }
        return TaskStatus.Running;



        return base.OnUpdate();
    }

}
