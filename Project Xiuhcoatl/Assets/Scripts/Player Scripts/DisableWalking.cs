using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWalking : MonoBehaviour {

    public GameObject controllerRight, controllerLeft;
    private int order;
    private bool used = false;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        if ((controllerRight.GetComponent<VRTouchpadMove>().trackpadTouched) && used == false) { order = 1; used = true; }
        if ((controllerLeft.GetComponent<VRTouchpadMove>().trackpadTouched) && used == false) { order = 2; used = true; }
        if (!(controllerRight.GetComponent<VRTouchpadMove>().trackpadTouched) && 
            !(controllerLeft.GetComponent<VRTouchpadMove>().trackpadTouched)) { order = 3; used = false; }

        switch (order)
        {
            case 1:
                controllerLeft.GetComponent<VRTouchpadMove>().working = false;
                controllerRight.GetComponent<VRTouchpadMove>().working = true;
                break;
            case 2:
                controllerRight.GetComponent<VRTouchpadMove>().working = false;
                controllerLeft.GetComponent<VRTouchpadMove>().working = true;
                break;
            case 3:
                controllerLeft.GetComponent<VRTouchpadMove>().working = true;
                controllerRight.GetComponent<VRTouchpadMove>().working = true;
                break;

        }
        /*
        if (controllerRight.GetComponent<VRTouchpadMove>().trackpadTouched)
        {
            controllerLeft.GetComponent < VRTouchpadMove>().working = false;
            controllerRight.GetComponent<VRTouchpadMove>().working = true;
        }
        if(controllerLeft.GetComponent<VRTouchpadMove>().trackpadTouched)
        {
            controllerRight.GetComponent < VRTouchpadMove>().working = false;
            controllerLeft.GetComponent<VRTouchpadMove>().working = true;
        }
        if (!(controllerRight.GetComponent<VRTouchpadMove>().trackpadTouched) && !(controllerLeft.GetComponent<VRTouchpadMove>().trackpadTouched))
        {
            controllerLeft.GetComponent<VRTouchpadMove>().working = true;
            controllerRight.GetComponent < VRTouchpadMove>().working = true;
        }*/

    }
}
