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
            if (shotArrow == false)
            {
                var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            }
           // Debug.Log(timer); 
            if (timer >= shootTime && shotArrow == false)
            {
                Instantiate(arrow, arrowSpawn.transform.position, transform.rotation);
                shotArrow = true;
            }

        }
       
    }
}