using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        print("Triggered");
    }

    private void OnCollisionEnter(Collision other) 
    {
        print("collided");
    }

}
