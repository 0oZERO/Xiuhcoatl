using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour {

    public GameObject arrow;
    public GameObject arrowSpawn; 
    public GameObject trigger; 
    public Transform player;
    public float speed;
    public float shootTime; 
    float timer;
    bool turretOn = false, shotArrow = false;

    void Update()
    {
         
       bool turretOn = trigger.GetComponent<TurretTrack>().turretOn;

        if(turretOn == true)
        {
            timer += Time.deltaTime;
            //timer = 0.0f; 
            if (timer < shootTime + 2)
            {
                var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            }
           // Debug.Log(timer); 
            if (timer >= shootTime && shotArrow == false)
            {
   
                var newArrow = Instantiate(arrow, arrowSpawn.transform.position, transform.rotation);
                newArrow.transform.parent = arrowSpawn.transform;
                shotArrow = true;
            }

        }
       
    }
}