using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour {

    public GameObject arrow;
    public GameObject arrowSpawn; 
    public GameObject trigger; 
    public Transform player;
    public float speed;
    public float shootTime, delayTime; 
    float timer;
    bool turretOn = false, shotArrow = false, audioPlayed = false;

    void Update()
    {
        timer += Time.deltaTime;
        AudioSource audio = GetComponent<AudioSource>(); 
       bool turretOn = trigger.GetComponent<TurretTrack>().turretOn;
        
        if(turretOn == true)
        {
            if (timer > delayTime)
            {
                //timer = 0.0f; 
                if (timer < shootTime + 2)
                {
                    if (audioPlayed == false)
                    {
                        audio.Play();
                        audioPlayed = true;
                    }
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
            
        else
        {
            timer = 0.0f; 
        }
       
    }
}