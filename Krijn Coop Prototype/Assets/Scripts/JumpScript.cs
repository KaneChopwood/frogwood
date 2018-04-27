using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour {

    
    public bool isJumping = false;
    public float jumpHeight;
    public float incrementalJumpAscent;
    public float incrementalJumpDescent;
    public CharacterController controller;

    private float verticalMovement;


    // Use this for initialization
    void Start () {
         
    }

    // Update is called once per frame
    void Update()
    {

        //applies gravity while falling
        if (controller.isGrounded == false)
        {
            if (isJumping == false)
            {
                incrementalJumpAscent = incrementalJumpDescent / 2;
                verticalMovement = transform.position.y - incrementalJumpDescent;
            }

            else
            {

                if (transform.position.y < jumpHeight)
                {
                    incrementalJumpAscent = incrementalJumpAscent * 2;
                    verticalMovement = transform.position.y + incrementalJumpAscent;
                }

                else
                {
                    isJumping = false;
                    incrementalJumpDescent = incrementalJumpAscent;
                    incrementalJumpAscent = 0.1f;
                }
            }
        }

        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
            }            
        }


        transform.position = new Vector3(transform.position.x, transform.position.y + verticalMovement, transform.position.z);
        print("isGrounded = " + controller.isGrounded);
        print("isJumping = " + isJumping);

    }


     





}
