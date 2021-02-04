using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitions : MonoBehaviour
{

    [SerializeField] Animator _crossfadeAnim;

    public void StartTransition()
    {   
        _crossfadeAnim.SetTrigger("Load Level");
        print("trans");
    }

}
