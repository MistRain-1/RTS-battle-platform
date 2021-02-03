
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using UnityEngine.AI;


public class GYQ_MySeek : Action
{

    public SharedFloat speed;

    public SharedFloat angularSpeed;

    public SharedFloat arriveDistance = 0.1f;

    public SharedTransform targetTransform;

    public SharedVector3 targetPosition;

    // True if the target is a transform
    private bool dynamicTarget;
    // A cache of the NavMeshAgent
    private NavMeshAgent navMeshAgent;

    private TankHealth health;


    public override void OnAwake()
    {
        // cache for quick lookup
        navMeshAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public override void OnStart()
    {
        // the target is dynamic if the target transform is not null and has a valid
        dynamicTarget = (targetTransform != null && targetTransform.Value != null);

        health = this.GetComponent<TankHealth>();

        // set the speed, angular speed, and destination then enable the agent
        navMeshAgent.speed = speed.Value;
        navMeshAgent.angularSpeed = angularSpeed.Value;
        navMeshAgent.enabled = true;
        navMeshAgent.destination = Target();
    }

    // Seek the destination. Return success once the agent has reached the destination.
    // Return running if the agent hasn't reached the destination yet
    public override TaskStatus OnUpdate()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < arriveDistance.Value)
        {
            health.isHurt = false;
            return TaskStatus.Success;
        }

        // Update the destination if the target is a transform because that agent could move
        if (dynamicTarget)
        {
            navMeshAgent.destination = Target();
        }
        return TaskStatus.Running;
    }

    public override void OnEnd()
    {
        // Disable the nav mesh
        navMeshAgent.enabled = false;
    }

    // Return targetPosition if targetTransform is null
    private Vector3 Target()
    {
        if (dynamicTarget)
        {
            return targetTransform.Value.position;
        }
        return targetPosition.Value;
    }

    // Reset the public variables
    public override void OnReset()
    {
        arriveDistance = 0.1f;
    }
}
