using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//-------------------------------------------------------------------------------------------------\\
// This code has been developed by Feisty Crab Studios for personal, commercial, and education use.\\
//                                                                                                 \\
// You are free to edit and redistribute this code, subject to the following:                      \\
//                                                                                                 \\
//      1. You will not sell this code or an edited version of it.                                 \\
//      2. You will not remove the copyright messages                                              \\
//      3. You will give credit to Feisty Crab Studios if used commercially                        \\
//      4. Don't be a mean sausage, nobody likes a mean sausage.                                   \\
//                                                                                                 \\
// Contact us @ feistycrabstudios.gmail.com with any questions.                                    \\
//-------------------------------------------------------------------------------------------------\\

public class VRTouchpadMove : MonoBehaviour
{
    float speed;
    public float speedWalk, multiplier;
    public bool isSprinting, disableMove, trackpadTouched = false, working = true;
    [SerializeField]
    //public Rigidbody rig;
    public CharacterController rig;
    public GameObject directionObj;
    public float fallSpeed;
    CapsuleCollider colliderPos;
    public Transform playerHead;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    bool isWalking; 



    private Valve.VR.EVRButtonId touchpad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private Valve.VR.EVRButtonId touchpadDown = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;


    private Vector2 axis = Vector2.zero;
    public Vector2 controllerAxis;

    public float maxSpeed;

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void FixedUpdate()
    {
       
        // rig.transform.position = new Vector3(playerHead.transform.position.x, playerHead.transform.position.y, playerHead.transform.position.z);
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return; 
        }

        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (disableMove != true)
        {

            if (device.GetPress(touchpadDown)) 
            {
                axis = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);

                if (rig != null)
                {
                    //speed = speedWalk;
                    trackpadTouched = false;
                    speed = (Mathf.Abs(device.velocity.y)) * multiplier;
                    //rig.velocity = new Vector3(directionObj.transform.right * axis.x, 0, 0);
                    //rig.MovePosition(rig.transform.position + directionObj.transform.forward * speed);

                    rig.SimpleMove((directionObj.transform.right * axis.x + directionObj.transform.forward * axis.y) * speed);
                    /*
                    if (rig.isGrounded)
                    {
                        moveDirection = new Vector3(axis.x, 0, axis.y);
                        moveDirection = transform.TransformDirection(moveDirection);
                        moveDirection *= speed;

                        //speed = (Mathf.Abs(device.velocity.x) + Mathf.Abs(device.velocity.y))/multiplier;
                        //rig.AddForce(((directionObj.transform.right * axis.x + directionObj.transform.forward * axis.y) * speed), ForceMode.Force);
                        // rig.velocity = Vector3.ClampMagnitude(rig.velocity, maxSpeed); //limits movement speed
                        //rig.MovePosition(rig.position.x, rig.position.y, rig.position.z); //zero out height
                        //Debug.Log("x value: " + axis.x + " y value " + axis.y);


                        //TEST
                        //SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(500);
                    }
                    */
                }
            }
            else if (device.GetTouch(touchpadDown))
            {
                axis = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);

                if (rig != null)
                {
                    trackpadTouched = true;
                    if (working == true)
                    {
                        speed = speedWalk;
                        //speed = (Mathf.Abs(device.velocity.y)) / multiplier;
                        //rig.velocity = new Vector3(directionObj.transform.right * axis.x, 0, 0);
                        //rig.MovePosition(rig.transform.position + directionObj.transform.forward * speed);

                        rig.SimpleMove((directionObj.transform.right * axis.x + directionObj.transform.forward * axis.y) * speed);
                    }
                    /*
                    if (rig.isGrounded)
                    {
                        moveDirection = new Vector3(axis.x, 0, axis.y);
                        moveDirection = transform.TransformDirection(moveDirection);
                        moveDirection *= speed;

                        //speed = (Mathf.Abs(device.velocity.x) + Mathf.Abs(device.velocity.y))/multiplier;
                        //rig.AddForce(((directionObj.transform.right * axis.x + directionObj.transform.forward * axis.y) * speed), ForceMode.Force);
                        // rig.velocity = Vector3.ClampMagnitude(rig.velocity, maxSpeed); //limits movement speed
                        //rig.MovePosition(rig.position.x, rig.position.y, rig.position.z); //zero out height
                        //Debug.Log("x value: " + axis.x + " y value " + axis.y);


                        //TEST
                        //SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(500);
                    }
                    */
                }
                
                //moveDirection.y -= gravity * Time.deltaTime;
                //rig.Move(moveDirection * Time.deltaTime);
            }
            else
            {
                trackpadTouched = false;
                rig.SimpleMove(new Vector3(0,0,0) * speed);
            }
            //rig.SimpleMove((directionObj.transform.right + directionObj.transform.forward) * speed);
        }
    } 
}