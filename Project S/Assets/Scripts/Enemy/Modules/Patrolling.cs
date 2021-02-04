using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrolling : MonoBehaviour
{
    [SerializeField] int _count = 0;
    public Transform[] _points;
    NavMeshAgent _agent;
    bool _finding;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if(_points.Length <2)
        {
            Debug.LogError("Not enough patrolling points for (" + transform.name + ")");
        }
        if(_agent == null)
        {
            Debug.LogError("NavMeshAgent not present on ("+transform.name+")");
        }  
       _agent.SetDestination(_points[_count].position);
       _finding = true;    
    }

    public void Cyclying()
    {        
        if(_agent.remainingDistance <=1 && _finding)
        {
            _finding = false;
            _count++;
        }
        else if(!_finding)
        {
            _finding = true;
        }
        if(_count>(_points.Length-1 ))
        {
            _count = 0;
        }
            _agent.SetDestination(_points[_count].position);
    }
}
