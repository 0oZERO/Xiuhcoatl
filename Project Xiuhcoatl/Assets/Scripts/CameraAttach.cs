using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAttach : MonoBehaviour {

    public CharacterController playerCol; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(playerCol.transform.position.x, playerCol.transform.position.y, playerCol.transform.position.z); 
	}
}
