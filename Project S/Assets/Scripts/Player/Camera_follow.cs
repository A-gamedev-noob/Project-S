using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
 
    [SerializeField] Transform _player;   
    public Vector3 _offset = new Vector3(0,10,-7);
    [SerializeField] float _damp = 0.125f;
    Vector3 vel = Vector3.one;

    void FixedUpdate()
    {
       Vector3 pos = _player.position + _offset;
       Vector3 smoothpos = Vector3.SmoothDamp(transform.position, pos, ref vel, _damp);
       transform.position = smoothpos; 
    }
}
