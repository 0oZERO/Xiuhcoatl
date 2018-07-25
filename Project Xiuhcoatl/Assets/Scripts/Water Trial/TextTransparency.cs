using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTransparency : MonoBehaviour
{
    public float transparency;
    bool changeTrans;
    public MeshRenderer text;
    public float opacity;
    public float transSpeed;
    public float red;
    public float green;
    public float blue;
    public float startTime, pauseTime;
    private float timer, stopTime;
    private bool activate, reset, sound;

    // Use this for initialization
    void Start()
    {
        transparency = 0.0f;
        changeTrans = false;
        activate = false;
        reset = false;
        sound = false;
        stopTime = pauseTime + startTime;
    }
    /*public void OnTriggerStay(Collider other)
    {
            changeTrans = true;
    }
    public void OnTriggerExit(Collider other)
    {
            changeTrans = false;
    }*/


    // Update is called once per frame
    void Update()
    {
        Debug.Log(activate);
        AudioSource audio = GetComponent<AudioSource>();
        if (reset == false)
        {
            if (transparency < 0.0f)
            {
                transparency = 0.0f;
            }
        }
        //activate = trigger.GetComponent<TextActivation>().active;
        timer += Time.deltaTime;
        if ((activate == true) && (reset == false))
        {
            timer = 0;
            reset = true;
        }
        if ((activate == true) && (reset == true))
        {
            if (timer >= stopTime)
            {
                if (transparency > 0.0f)
                {
                    transparency -= transSpeed;
                }
            }
            else if (timer >= startTime)
            {
                if (transparency < opacity)
                {
                    if (sound == false)
                    {
                        audio.Play();
                        sound = true;
                    }
                    transparency += transSpeed;
                }
            }
        }
        text.GetComponent<MeshRenderer>().material.color = new Color(red, green, blue, transparency);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            activate = true;
        }
    }
}