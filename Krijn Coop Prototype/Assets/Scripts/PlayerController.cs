using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movespeed;
    //public Rigidbody RB;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

    public Transform pivot;
    public float rotateSpeed;

    public GameObject playerModel;

    
    //jumping lerp
    public float jumpSpeed;
    private float startTime;
    private float journeyLength;
    private Vector3 jumpStartPosition;
    private Vector3 jumpTopPosition;
    public bool isJumping = false;
        

    // Use this for initialization
    void Start () {
        //controller = GetComponent<CharacterController>();
        

    }
	
	// Update is called once per frame
	void Update () {
        
        moveDirection = (transform.forward * Input.GetAxis("Vertical") * movespeed) + (transform.right * Input.GetAxis("Horizontal") * movespeed);
        
        
        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                startTime = Time.time;
                jumpStartPosition = transform.position;                                
                journeyLength = Vector3.Distance(jumpStartPosition, jumpTopPosition);
                isJumping = true;
            }
        }

        if (isJumping == true)
        {
            //putting the following jumpTopPosition with a new Vector3 during the isJumping phase of the jump ensures that the X and Z axis are updated when moving around. 
            //This because the isJumping section is executed multiple times, and the Input.GetButton("Jump") part is only executed once.
            jumpTopPosition = new Vector3(transform.position.x, jumpStartPosition.y + jumpForce, transform.position.z);


            float distanceCovered = (Time.time - startTime) * jumpSpeed;
            float fracJourney = distanceCovered / journeyLength;
            Debug.Log("jumpStartPosition: " + jumpStartPosition);
            Debug.Log("jumpTopPosition: " + jumpTopPosition);
            Debug.Log("fracJourney: " + fracJourney);

            transform.position = Vector3.Lerp(jumpStartPosition, jumpTopPosition, fracJourney);


            

        }
        
        if (transform.position.y == jumpTopPosition.y)
        {
            isJumping = false;
        }

        if (isJumping == false)
        {
            moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        }
        
        



        //Applies x Y and Z axis movement (jumping)
        controller.Move(moveDirection * Time.deltaTime);


        //debug prints
        /*
        print("controller isGrounded = " + controller.isGrounded);
        print("jump button pressed = " + Input.GetButtonDown("Jump"));
        print("jumpStartPosition = " + jumpStartPosition);
        print("jumpTopPosition = " + jumpTopPosition);
        print("journeyLength = " + journeyLength);
        print("journeyLength = " + journeyLength);
        */

        //Move the player in different directions based on camera look direction
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) 
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }          

	}
}
