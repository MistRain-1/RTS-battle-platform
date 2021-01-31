using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class zmz_TankState : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent na;

    public enum State
    {
        None,
        Patrol,
        Chase,
        Attack,
    }
    Rigidbody rb;
    State stat;
    public Transform enemy;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stat = State.Patrol;
        na = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (zmz_EyesRange.IsTrriger == true)
            stat = State.Attack;    
        switch (stat)
        {
            case State.Patrol:
                StatePatrol();
                break;
            case State.Chase:
                StateChase();
                break;
            case State.Attack:
                StateAttack();
                break;
        }
    }
    void StatePatrol()
    {
        na.SetDestination(enemy.position);
        Debug.Log("now_patrol");
    }
    void StateChase()
    {
        rb.Sleep();
        Debug.Log("now_chase");
    }
    void StateAttack()
    {
        Debug.Log("now_attack");
    }
}
