using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerClosingWalls : MonoBehaviour {

    public GameObject wall1, wall2;
    bool wall1Touch, wall2Touch;
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player Head");
        
    }

    // Update is called once per frame
    void Update () {

        wall1Touch = wall1.GetComponent<ClosingWalls>().isTouching;
        wall2Touch = wall2.GetComponent<ClosingWalls>().isTouching;
		Debug.Log(wall1Touch); 
        if(wall1Touch == true && wall2Touch == true)
        {
            player.GetComponent<DeathCheck>().deathInput = 3;
            
        }
	}
}
