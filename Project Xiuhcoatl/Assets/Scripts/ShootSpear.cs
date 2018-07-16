using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpear : MonoBehaviour {


    public float xSpeed;
    public float ySpeed;
    public float zSpeed;
    public float damage;
    void Update()
    {
        transform.Translate(new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collide)
    {
        if (collide.transform.name == "Player")
        {
            //collide.GetComponent<Health>().removeHealth(damage);
        }
       
    }



}
