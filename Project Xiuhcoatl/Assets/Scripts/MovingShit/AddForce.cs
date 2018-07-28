using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {

    public float force;
    public GameObject boulder;
    AudioSource audio;

    void Start()
    {
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
