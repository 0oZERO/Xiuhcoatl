﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller))]
public class Hand : MonoBehaviour
{
    GameObject heldObject;
    Controller controller;
    bool isHeld; 

    Rigidbody simulator;

    void Start()
    {
        simulator = new GameObject().AddComponent<Rigidbody>();
        simulator.name = "simulator";
        simulator.transform.parent = transform.parent;
        controller = GetComponent<Controller>();
    }

    void Update()
    {
        if (heldObject)
        {
            simulator.velocity = (transform.position - simulator.position) * 50f;
            simulator.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
            if (controller.controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_Grip))
            {
                heldObject.transform.parent = null;
                heldObject.GetComponent<Rigidbody>().isKinematic = false;
                heldObject.GetComponent<Rigidbody>().useGravity = true;
                heldObject.GetComponent<Rigidbody>().velocity = simulator.velocity;
                heldObject.GetComponent<HeldObject>().parent = null;
                heldObject = null;
            }
        }
        else
        {
            if (controller.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip))
            {
                Collider[] cols = Physics.OverlapSphere(transform.position, 0.1f);

                foreach (Collider col in cols)
                {
                    if (heldObject == null && col.GetComponent<HeldObject>() && col.GetComponent<HeldObject>().parent == null)
                    {
                        heldObject = col.gameObject;
                        heldObject.transform.parent = transform;
                        heldObject.transform.localPosition = Vector3.zero;
                        heldObject.transform.localRotation = Quaternion.identity;
                        heldObject.GetComponent<Rigidbody>().isKinematic = true;
                        heldObject.GetComponent<HeldObject>().parent = controller;
                    }
                }
            }
        }

        if (controller.controller.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
        { 
            simulator.velocity = (transform.position - simulator.position) * 50f;
        simulator.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        
            Collider[] cols = Physics.OverlapSphere(transform.position, 0.1f);

            foreach (Collider col in cols)
            {
                if (heldObject == null && col.GetComponent<HeldObject>() && col.GetComponent<HeldObject>().parent == null)
                {
                    heldObject = col.gameObject;
                    heldObject.transform.parent = transform;
                    heldObject.transform.localPosition = Vector3.zero;
                    heldObject.transform.localRotation = Quaternion.identity;
                    heldObject.GetComponent<Rigidbody>().isKinematic = true;
                    heldObject.GetComponent<HeldObject>().parent = controller;
                }
            }
        }
    
        else if (controller.controller.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
        {
            heldObject.transform.parent = null;
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            heldObject.GetComponent<Rigidbody>().velocity = simulator.velocity;
            heldObject.GetComponent<HeldObject>().parent = null;
            heldObject = null;
            isHeld = false; 
        }
    }
}