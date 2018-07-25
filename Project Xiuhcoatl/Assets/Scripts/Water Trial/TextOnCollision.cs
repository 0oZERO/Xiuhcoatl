using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnCollision : MonoBehaviour {
    public float transparency;
    bool changeTrans;
    public MeshRenderer text;
    public float opacity;
    public float transSpeed;
    public float red;
    public float green;
    public float blue;
    private bool activate, reset, sound;
    // Use this for initialization
    void Start () {
        activate = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (activate == true)
        {
            if (transparency < opacity)
            {
                transparency += transSpeed;
            }
        }
        else
        {
            if (transparency > 0.0f)
            {
                transparency -= transSpeed;
            }
        }
        text.GetComponent<MeshRenderer>().material.color = new Color(red, green, blue, transparency);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Vision"))
        {
            activate = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Vision"))
        {
            activate = false;
        }
    }
}
