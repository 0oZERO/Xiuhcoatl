using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpeed : MonoBehaviour {

    float timer;
    float shootTime; 
    public float speed,timeToShoot;
    bool spawnArrow; 

    void start()
    {
        timer = 0.0f; 
    }
	void Update () {
        timer += Time.deltaTime; 
        if(timer >= timeToShoot)
        {
            transform.Translate(0, 0, Time.deltaTime * speed); 
        }

        if (timer > 4.0f)
        {
            Destroy(this.gameObject); 
        }
	}
}
