using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingWalls : MonoBehaviour {
    
    GameObject player;
    public bool isTouching;
    private void Start()
    {
        player = GameObject.Find("Player Head");

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isTouching = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isTouching = false;
        }
    }
}
