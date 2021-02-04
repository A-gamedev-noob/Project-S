using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 _movedirection;
    [SerializeField] float _speed = 5f;
    [SerializeField] float _gravity = -19.2f;
    [SerializeField] Animator anim;
    CharacterController _controller;
    [SerializeField] float _rotation_smoothness = 0.1f;
    float turn;
    [SerializeField] Camera _cam;

    void Start()
    {
      _controller = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
      Motion();
    }

    private void Motion()
    {
      float x = Input.GetAxisRaw("Horizontal");
      float y = Input.GetAxisRaw("Vertical");
      _movedirection = new Vector3(x, 0, y);

      anim.SetFloat("Forward", y);
      anim.SetFloat("Turn", x);
      if (_movedirection.magnitude >= 0.1f)
      {
        float lookdir = Mathf.Atan2(_movedirection.x, _movedirection.z) * Mathf.Rad2Deg;
        float smoothrot = Mathf.SmoothDampAngle(transform.eulerAngles.y, lookdir, ref turn, _rotation_smoothness);
        Vector3 direction = Quaternion.Euler(0, smoothrot, 0).normalized * Vector3.forward;
        transform.rotation = Quaternion.Euler(0, smoothrot, 0);
        _controller.Move(direction.normalized * _speed * Time.deltaTime);
      }
    }
}

