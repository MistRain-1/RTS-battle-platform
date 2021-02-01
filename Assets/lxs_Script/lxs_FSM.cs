using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lxs_FSM : MonoBehaviour
{
    public enum FSMstate { 
        None,
        Patrol,
        Chase,
        Attack
    }
    public FSMstate curState;

    // Start is called before the first frame update
    void Start()
    {
        curState = FSMstate.Patrol;
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (curState)
        {
            case FSMstate.Patrol:
                StatePatrol();
                break;
            case FSMstate.Chase:
                StateChase();
                break;
            case FSMstate.Attack:
                StateAttack();
                break;
        }
    }
    void StatePatrol()
    {
        Debug.Log("1");
    }
    void StateChase()
    {
        Debug.Log("2");
    }
    void StateAttack()
    {
        Debug.Log("3");
    }
}
