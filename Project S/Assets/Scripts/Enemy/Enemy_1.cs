using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_1 : MonoBehaviour
{
    bool _attacking;
    enum State{attacking,patrolling,searching}
    [SerializeField] State _currentstate;
    NavMeshAgent _agent;
    public bool _isdetected ;

    [SerializeField] GameObject _player;
    [SerializeField] GameManager _Manager;
    [SerializeField] FeildOfView _fov;

    //Other Scripts
    Patrolling _pat;

    void Start()
    {
        _attacking = false;
        _currentstate = State.patrolling;
        _pat = GetComponent<Patrolling>();
        if(_pat == null)
        {
            Debug.Log("Patrolling Script not present");
        }
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        SetTarget();
        Attacking();
        Detected();
    }

    void SetTarget()
    {
        if(_currentstate == State.patrolling)
        {
            _pat.Cyclying();
        }
    }

    void Attacking()
    {
        if(_currentstate == State.attacking)
        {
           _agent.SetDestination(_player.transform.position);
           _agent.stoppingDistance = 3;
           _agent.angularSpeed = 2000f;
           _agent.speed = 12f;
           if(_agent.remainingDistance<=3)
           {
               _Manager.Restart(1f);
           }
        }
    }

    void Detected()
    {
        _isdetected = _fov.Seen();
        if(_isdetected)
        {
            _currentstate = State.attacking;
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.transform.CompareTag("Player"))
        {
            _Manager.Restart(1f);
        }    
    }
}
