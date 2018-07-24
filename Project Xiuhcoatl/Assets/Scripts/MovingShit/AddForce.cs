using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {

    public float force; 
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddForce(0, 0, force); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
