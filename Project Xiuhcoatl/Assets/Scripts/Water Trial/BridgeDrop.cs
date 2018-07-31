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
        if (other.gameObject == triggerObj)
        {
            bridge.GetComponent<Rigidbody>().useGravity = true;
            bridge.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    private void Update()
    {

    }
}
