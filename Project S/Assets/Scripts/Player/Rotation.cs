using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    [SerializeField] Camera _cam;

    // Update is called once per frame
    void Update()
    {
       Targeting();
    }

    void Targeting()
    {
        RaycastHit hitinfo;
        var mousepos = Input.mousePosition;
        Ray ray = _cam.ScreenPointToRay(mousepos);
        if(Physics.Raycast(ray.origin, ray.direction, out hitinfo))
        {
            Rotating(hitinfo.point, gameObject);
        }
    }

    void Rotating(Vector3 contact, GameObject obj)
    {
        Vector3 dir = contact - obj.transform.position;
        Vector3 dirf;
        Quaternion rotf;
        if(contact.y<=obj.transform.position.y)
        {
            dirf = dir + new Vector3(0,obj.transform.position.y, 0);
        }
        else
        {
            dirf = dir - new Vector3(0,obj.transform.position.y, 0);
        }
        rotf = Quaternion.LookRotation(dirf);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotf, 1);
    }
}
