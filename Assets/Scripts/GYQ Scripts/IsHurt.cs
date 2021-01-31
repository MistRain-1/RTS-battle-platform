using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using UnityEngine.AI;

public class IsHurt:Conditional
{
    private TankHealth health;
    public override void OnAwake()
    {
        health = this.GetComponent<TankHealth>();
    }

    public override TaskStatus OnUpdate()
    {
        if (!health.isHurt)
        {
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }

}
