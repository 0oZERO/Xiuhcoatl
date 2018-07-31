using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransOnCol : MonoBehaviour {

    public GameObject ceiling, torch;
    public float speed, transTime;
    float timer; 
    bool transStart = false;
    //AudioSource audio; 


    void Start()
    {

        //audio = ceiling.GetComponent<AudioSource>(); 
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == torch)
        {
            transStart = true; 
            //audio.Play(); 
        }
    }
    void Update()
    {
        timer += Time.deltaTime; 
    if (transStart == true)
        {
            if (timer <= transTime)
            {
                ceiling.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else if (timer > transTime)
            {
                ceiling.transform.Translate(Vector3.forward * -speed * Time.deltaTime);
                if (timer > transTime * 2)
                {
                    timer = 0.0f;
                }
            }
        }
    else if(transStart == false)
        {
            timer = 0.0f; 
        }
    }
}
