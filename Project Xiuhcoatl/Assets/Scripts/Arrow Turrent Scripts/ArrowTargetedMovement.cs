using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTargetedMovement : MonoBehaviour
{

    //public GameObject player;
    public float speed;
    bool shoot = false; 

    // Use this for initialization
    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");

    }

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
        /*
        if(shoot == false)
        {
          transform.LookAt(player.transform);
        }


        if (Input.GetKeyDown("space"))
        {
            shoot = true; 
        }

        if(shoot == true)
        {
            
        }
        */

    }
}
