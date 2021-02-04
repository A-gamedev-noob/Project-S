using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeildOfView : MonoBehaviour
{
    public float _viewRadius = 5f;
    [Range(0,360)] public float _viewAngle = 45f;

    [SerializeField] LayerMask _player;
    [SerializeField] LayerMask _nonPlayer;

    public List<Transform> _visibletargets = new List<Transform>();
    [SerializeField] bool seen = false;

    void Start()
    {
        StartCoroutine("sight");
    }

    public Vector3 Angle(float angleindeg, bool isGlobal)
    {
        if(!isGlobal)
        {
            angleindeg += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleindeg *Mathf.Deg2Rad), 0, Mathf.Cos(angleindeg * Mathf.Deg2Rad));
    }

    IEnumerator sight()
    {
        while(true)
        {
            FindVisibleTargets();
            yield return new WaitForSeconds(0.2f);
        }
    }

    void FindVisibleTargets()
    {
        _visibletargets.Clear();
        Collider[] targetsinViewRadius = Physics.OverlapSphere(transform.position,_viewRadius, _player);
        for(int a=0; a<targetsinViewRadius.Length; a++)
        {
            Transform target = targetsinViewRadius[a].transform;
            Vector3 dirtotarget = (target.position - transform.position);
            if(Vector3.Angle(transform.forward, dirtotarget) < _viewAngle/2)
            {
                float dst = Vector3.Distance(transform.position, target.position);
                if(!Physics.Raycast(transform.position, dirtotarget, dst, _nonPlayer))
                {
                    _visibletargets.Add(target);
                    seen = true;
                }
            }
        }
    }

    public bool Seen()
    {
        bool isdetected = seen;
        return isdetected;
    }
}
