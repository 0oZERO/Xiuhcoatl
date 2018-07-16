using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoMove : MonoBehaviour {

    public GameObject controller; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = controller.transform.position;
        transform.eulerAngles = new Vector3 (0, controller.transform.eulerAngles.y, 0);
	}
}
