using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDeath : MonoBehaviour {

    //Sends a 1 to Script DeathCheck when a projectile hits the player. 
    GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player Head");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.GetComponent<DeathCheck>().deathInput = 1;
        }

    }
}
