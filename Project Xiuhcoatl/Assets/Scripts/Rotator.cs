using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public float speed;
    public float startTime;
    float timer; 
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime; 
        if(timer >= startTime)
        {
            transform.Rotate(speed, 0, 0, Space.Self);
        }

	}
}
