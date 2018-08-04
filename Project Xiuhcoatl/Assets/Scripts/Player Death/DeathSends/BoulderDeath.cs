using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderDeath : MonoBehaviour {

    GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player Head");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.GetComponent<DeathCheck>().deathInput = 2;
        }

    }
}
