using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_Points : MonoBehaviour
{
    [SerializeField] float _radius=1f;
    [SerializeField] Color _col = Color.green;
    
    private void OnDrawGizmos() 
    {
        Gizmos.color = _col;
        Gizmos.DrawWireSphere(transform.position,_radius);    
    }
}
