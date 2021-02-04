using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Animator _anim;

    public void Restart(float delay)
    {
        Invoke("Reload",delay);
    }

    private void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //REMOVE Update //REMOVE Update
    //REMOVE Update //REMOVE Update
    //REMOVE Update //REMOVE Update
    //REMOVE Update //REMOVE Update
    //REMOVE Update //REMOVE Update
    //REMOVE Update //REMOVE Update

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.F4))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }  
    }

    public void NewGame()
    {       
        Invoke("LoadNewGame",1f);
    }
    public void CrossFadeTransition()
    {
        _anim.SetTrigger("Load Level");
    }

    void LoadNewGame()
    {   
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
