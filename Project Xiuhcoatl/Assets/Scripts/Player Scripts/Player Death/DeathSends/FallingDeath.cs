using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDeath : MonoBehaviour {

    public GameObject playerCol;
    GameObject player;


    void Start () {
        playerCol = GameObject.Find("CameraRig");
        player = GameObject.Find("Player Head");
    }
	
	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            player.GetComponent<DeathCheck>().deathInput = 5;
        }
    }
}
