using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDeathUI : MonoBehaviour {

    bool enableDeathUI;
    GameObject player;

	void Start () {
        player = GameObject.Find("Player Head");
    }
	
	// Update is called once per frame
	void Update () {
        if (player.GetComponent<DeathCheck>().deathInput > 0)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
            this.GetComponent<Renderer>().material.mainTexture = player.GetComponent<DeathCheck>().displayTexture;
        }
        else
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
	}
}
