using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransOnCol : MonoBehaviour {

    public GameObject ceiling;
    public Transform startMarker, endMarker;
    public float speed; 
    bool transStart = false;
    AudioSource audio; 

    void Start()
    {
        audio = ceiling.GetComponent<AudioSource>(); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transStart = true;
            audio.Play(); 
        }
    }
    void Update()
    {
        if (transStart == true)
        {
            ceiling.transform.Translate(Vector3.up * -speed * Time.deltaTime);
        }
    }
}
