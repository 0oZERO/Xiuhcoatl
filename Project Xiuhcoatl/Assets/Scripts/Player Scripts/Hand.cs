using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller))]
public class Hand : MonoBehaviour
{
    GameObject heldObject, playerHead, reticle;
    Controller controller;
    [HideInInspector]
    public bool isHeld; 
    bool active; 
    Rigidbody simulator;
    

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    void Start()
    {
        playerHead = GameObject.FindWithTag("Player Head");
 
        simulator = new GameObject().AddComponent<Rigidbody>();
        simulator.name = "simulator";
        simulator.transform.parent = transform.parent;
        controller = GetComponent<Controller>();
        active = false;
    }

    void Update()
    {
        playerHead.GetComponent<Head>().active = active;
        if (heldObject)
        {
            simulator.velocity = (transform.position - simulator.position) * 50;
            simulator.angularVelocity = (transform.eulerAngles); //- simulator.transform.eulerAngles) * 2;
            if (controller.controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_Grip))
            {
                isHeld = false; 
                heldObject.transform.parent = null;
                heldObject.GetComponent<Rigidbody>().isKinematic = false;
                heldObject.GetComponent<Rigidbody>().useGravity = true;
                heldObject.GetComponent<Rigidbody>().velocity = Controller.velocity * 1.5f;
                heldObject.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
                heldObject.GetComponent<HeldObject>().parent = null;
                heldObject = null;
            }
            if (controller.controller.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                active = true;
                reticle = playerHead.GetComponent<Head>().temp;
            }

            playerHead.GetComponent<Head>().active = active;

            if (controller.controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
            {

                isHeld = false;
                heldObject.transform.parent = null;
                heldObject.GetComponent<Rigidbody>().isKinematic = false;
                heldObject.GetComponent<Rigidbody>().useGravity = true;
                heldObject.GetComponent<Rigidbody>().velocity = Controller.velocity * 3f;
                heldObject.GetComponent<Rigidbody>().transform.LookAt(reticle.transform);
                heldObject.GetComponent<HeldObject>().parent = null;
                heldObject = null;
                active = false; 
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
                        isHeld = true; 
                    }
                }
            }
            /*
            if (controller.controller.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
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
            */
        }

    }
}