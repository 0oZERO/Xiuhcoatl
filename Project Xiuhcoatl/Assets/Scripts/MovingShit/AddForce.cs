using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {
    public GameObject boulder; 
    public float force;
    bool audioPlayed = false;
    new AudioSource audio;
    // Use this for initialization
    void Start () {
        audio = boulder.GetComponent<AudioSource>();
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            boulder.GetComponent<Rigidbody>().AddForce(0, 0, force);
            audio.Play();
        }
    }
}
