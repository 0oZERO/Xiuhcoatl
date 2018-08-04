﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTrack : MonoBehaviour {

    [HideInInspector]
    public bool turretOn = false; 

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && turretOn == false)
        {
            turretOn = true;  
        }
    }
}