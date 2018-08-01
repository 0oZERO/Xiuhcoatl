using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour {
    public GameObject reticle, temp;
    public bool active, spawned, destroyed;
	// Use this for initialization
	void Start ()
    {
        destroyed = true;
        spawned = false;
        active = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (active == true)
        {
            RaycastHit hit;
            if(spawned == false)
            {
                temp = Instantiate(reticle);
                spawned = true;
                destroyed = false;
            }
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                Debug.Log("Did Hit");
                temp.transform.position = hit.point;
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }
        if(active == false)
        {
            if (destroyed == false)
            {
                GameObject.Destroy(temp);
                spawned = false;
                destroyed = true;
            }
        }
    }
}
