﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    CharacterController playerCol;
    //BoxCollider playerCol;
    public GameObject player;
    public GameObject playerGround; 
    float playerHeight;
    Transform playerScale;

    void Start()
    {
        //playerCol = this.GetComponent<CharacterController>(); 
         playerCol = this.GetComponent<CharacterController>();
        //playerCol = this.GetComponent<BoxCollider>(); 
       
        playerScale = this.gameObject.transform; 
    }
    void Update()
    {
        playerHeight = player.GetComponent<ColliderRaycast>().playerHeight;
        playerCol.height = playerHeight;
        //playerCol.size = new Vector3(0.5f, playerHeight, 0.5f);
        playerCol.center = new Vector3(player.transform.localPosition.x, playerHeight / 2, player.transform.localPosition.z);
        //this.gameObject.transform.position = player.transform.position;
        this.gameObject.transform.Rotate(0.0f,0.0f, 0.0f);

       //playerGround.transform.position = new Vector3(transform.position.x, player.GetComponent<ColliderRaycast>().hit.point.y, transform.position.z); 
        
    }
}
