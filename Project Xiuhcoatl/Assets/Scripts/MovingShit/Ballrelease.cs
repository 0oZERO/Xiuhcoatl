using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballrelease : MonoBehaviour {

    public GameObject ball; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Player"))
        {
            ball.GetComponent<Rigidbody>().useGravity = true; 
        }
    }
}
