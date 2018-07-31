using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HeldObject : MonoBehaviour {

    [HideInInspector]
    public Controller parent;
    bool isHeld;
    bool collided;
    Vector3 lastPosition;
    public GameObject hand;

   /*
    void Update()
    {

        if (transform.IsChildOf(hand.transform))
        {
            isHeld = true;
        }
        else
        {
            isHeld = false; 
            var direction = transform.position - lastPosition;
            var localDirection = transform.InverseTransformDirection(direction);
 

            var targetRotation = Quaternion.LookRotation(transform.forward);
            transform.rotation = targetRotation;  ;
        }
        Debug.Log(isHeld);
    }
    void LateUpdate()
    {
        lastPosition = transform.position;
    }
*/
}
