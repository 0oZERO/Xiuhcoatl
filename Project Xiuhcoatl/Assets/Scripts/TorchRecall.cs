using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchRecall : MonoBehaviour {

    public GameObject item;         //Torch
   // public GameObject otherHand; 
    public float speed = 10f;       //Throwing Strength
    bool inHand; 
    //public GameObject parentHandL, ParentHandR;         //ParentHandR = SteamVR right controller, ParentHandR = SteamVR left controller


    private Valve.VR.EVRButtonId menu = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;
    //bool isDown = SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).G

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    // Update is called once per frame
    void Update ()
    {
        // rig.transform.position = new Vector3(playerHead.transform.position.x, playerHead.transform.position.y, playerHead.transform.position.z);
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetPress(menu))      //Replace with SteamVR right hand designated button
        {
            item.transform.SetParent(this.transform);

            item.GetComponent<Rigidbody>().isKinematic = true;
            item.GetComponent<Rigidbody>().useGravity = false;

            item.transform.rotation = this.transform.rotation;
            item.transform.position = this.transform.position;

        }
        /*
        else if (Input.GetKeyDown(KeyCode.L))       //Replace with SteamVR left hand designated button
        {
            item.transform.SetParent(parentHandL.transform);

            item.GetComponent<Rigidbody>().isKinematic = true;
            item.GetComponent<Rigidbody>().useGravity = false;

            item.transform.rotation = parentHandL.transform.rotation;
            item.transform.position = parentHandL.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {   
            //ADD ANIMATION\\
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<Rigidbody>().useGravity = true;
            if (item.transform.parent == null)
            {
                //Prevents null error crash
            }
            else
            {
                item.GetComponent<Rigidbody>().velocity = transform.forward * speed;    //change transform.forward to parent controller velocity
                item.transform.SetParent(null);
            }
           
        }
        */
	}
}
