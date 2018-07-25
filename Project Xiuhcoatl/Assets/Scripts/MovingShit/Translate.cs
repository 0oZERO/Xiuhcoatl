using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour {

    public float speed;
    public float transTime, startTime;
    float timer, startTimer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timer += Time.deltaTime;
        startTimer += Time.deltaTime;
        if (startTimer >= startTime)
        {

            if(timer <= transTime)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime); 
            }
            else if (timer > transTime)
            {
                transform.Translate(Vector3.forward * -speed * Time.deltaTime);
                if (timer > transTime * 2)
                {
                    timer = 0.0f; 
                }
            }
        }
       


	}
}
