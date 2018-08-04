using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay : MonoBehaviour {
    public float red, green, blue, transparency; 
	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().material.color = new Color(red, green, blue, transparency);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
