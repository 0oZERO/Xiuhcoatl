using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeDrop : MonoBehaviour {
    public GameObject bridge, triggerObj;
    bool dropBridge;

    void Start()
    {
     
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bridge.GetComponent<Rigidbody>().useGravity = true; 
        }
    }
    private void Update()
    {
        Debug.Log(dropBridge); 
    }
}
