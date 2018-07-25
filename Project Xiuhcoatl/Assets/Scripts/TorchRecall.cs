using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchRecall : MonoBehaviour {

    public GameObject item;         //Torch
    public float speed = 10f;       //Throwing Strength
    public GameObject parentHandL, ParentHandR;         //ParentHandR = SteamVR right controller, ParentHandR = SteamVR left controller

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))        //Replace with SteamVR right hand designated button
        {
            item.transform.SetParent(ParentHandR.transform);

            item.GetComponent<Rigidbody>().isKinematic = true;
            item.GetComponent<Rigidbody>().useGravity = false;

            item.transform.rotation = ParentHandR.transform.rotation;
            item.transform.position = ParentHandR.transform.position;
        }
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
	}
}
