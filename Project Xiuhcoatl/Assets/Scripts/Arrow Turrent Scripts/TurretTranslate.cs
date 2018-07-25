using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTranslate : MonoBehaviour {
    public GameObject[] turrets;
    bool translate = true;
    


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (translate == true)
            {
                foreach (GameObject turret in turrets)
                {
                    Vector3 startMarker;
                    Vector3 endMarker;

                    startMarker = new Vector3(turret.transform.position.x, turret.transform.position.y, turret.transform.position.z);
                    endMarker = new Vector3(turret.transform.position.x, turret.transform.position.y, startMarker.z + 5);
                    turret.transform.position = Vector3.Lerp(startMarker, endMarker, 0.5f);

                    translate = false; 
                }
            }
        }
    }

   
}
