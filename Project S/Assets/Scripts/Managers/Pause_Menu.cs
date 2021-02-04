using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Pause_Menu : MonoBehaviour
{

    [SerializeField] GameObject _pm;
    bool _ispaused;
    [SerializeField] GameObject _ppv; 

    void Start()
    {
       _pm.SetActive(false); 
       _ppv.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !_ispaused)
        {
            Pause();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && _ispaused)
        {
            Resume();
        }
    }

    public void Pause()
    {
        _pm.SetActive(true);
        _ispaused = true;
        Time.timeScale = 0;
        _ppv.SetActive(true);
    }

    public void Resume()
    {
        _pm.SetActive(false);
        _ispaused = false;
        Time.timeScale = 1f;
        _ppv.SetActive(false);
    }
}
