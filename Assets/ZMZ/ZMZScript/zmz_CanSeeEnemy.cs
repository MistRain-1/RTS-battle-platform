using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zmz_CanSeeEnemy :Action
{
    Transform[] targets;
    public float fieldOfViewAngle;
    public float viewDistance;
    public static Transform target;
    
   


    public override void OnAwake()
    {
        targets = Resources.FindObjectsOfTypeAll(typeof(Transform)) as Transform[];
        //for (int i = 0; i < targets.Length; i++)
        //{
        //    if (targets[i].gameObject.layer > 14)
        //    {
        //        target = targets[i];
        //    }
        //}
    }
    public override TaskStatus OnUpdate()
    {

        for (int i = 0; i < targets.Length; i++)
        {
            
            float distance = (targets[i].position - transform.position).magnitude;
            float angle = Vector3.Angle(transform.forward, targets[i].position - transform.position);

            if (distance < viewDistance && angle < fieldOfViewAngle * 0.5f&& targets[i].gameObject.layer > 14)
            {
                //targetss.Add(targets[i]); 
                target = targets[i];
                return TaskStatus.Success;
            }
        }
        if (target == null) return TaskStatus.Failure;

        return TaskStatus.Failure;
    }
}
