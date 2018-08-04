using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelingCrushDeath : MonoBehaviour {

    public float ceilingHeight;
    float playerHeight;
    GameObject playerHeightObj;
    GameObject player;
    bool isCol; 
 
    public RaycastHit hit;

    void Start () {
        playerHeightObj = GameObject.Find("Camera (eye)");
        player = GameObject.Find("Player Head");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            isCol = true; 
        }
    }

    // Update is called once per frame
    void Update () {
        playerHeight = playerHeightObj.GetComponent<ColliderRaycast>().playerHeight; 
        Ray height = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(height, out hit))
        {
            ceilingHeight = hit.distance;

        }

        if((ceilingHeight < playerHeight) && (isCol == true))
        {
            player.GetComponent<DeathCheck>().deathInput = 4;
        }
        Debug.DrawLine(this.gameObject.transform.position, hit.point, Color.red);
    }
}
