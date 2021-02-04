using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(FeildOfView))]
public class ED_FOV : Editor
{
    private void OnSceneGUI() 
    {
        FeildOfView tar = (FeildOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(tar.transform.position, Vector3.up, Vector3.forward, 360, tar._viewRadius);

        Vector3 angleA = tar.Angle(-tar._viewAngle/2, false);
        Vector3 angleB = tar.Angle(tar._viewAngle / 2, false);
        Handles.DrawLine(tar.transform.position , tar.transform.position + angleA * tar._viewRadius);
        Handles.DrawLine(tar.transform.position, tar.transform.position + angleB * tar._viewRadius);

        Handles.color = Color.red;
        foreach(Transform visibleTargets in tar._visibletargets)
        {
            Handles.DrawLine(tar.transform.position, visibleTargets.position);
        }
    }  
}
