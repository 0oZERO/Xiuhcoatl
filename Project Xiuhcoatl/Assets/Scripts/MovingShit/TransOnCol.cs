using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransOnCol : MonoBehaviour {


    public GameObject ceiling;
    public Transform startMarker, endMarker;
    public float speed; 
    bool transStart = false, audioPlayed = false; 

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transStart = true; 
        }
    }
    void Update()
    {
        AudioSource audio = ceiling.GetComponent<AudioSource>(); 
        if (transStart == true)
        {
            if (audioPlayed == false)
            {
             audio.Play();
                audioPlayed = true; 
            }
            ceiling.transform.Translate(Vector3.up * -speed * Time.deltaTime);

        }
    }
}
