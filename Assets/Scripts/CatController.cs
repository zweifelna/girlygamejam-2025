using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CatController : MonoBehaviour
{
    Vector2 catPosition;
    public Vector2 catSpeed = new Vector2(-1,0);

    // Start is called before the first frame update
    void Start()
    {
        this.catPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = catPosition;

        if(Input.GetKey(KeyCode.A)){
            Debug.Log("A appuyé");
            catPosition += catSpeed;
        } 
        
    }
}
