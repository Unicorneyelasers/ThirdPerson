using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 6.0f;
    private float rotSpeed = 360.0f;
   //gravity variables 
    private float gravity = -9.81f;
    private float yVelocity = 0.0f;
    private float yVelocityGrounded = -4.0f;
    //jump veriables
    private float jumpHeight = 3.0f;
    private float jumpTime = 0.5f;
    private float initialjumpVelocity;
    private bool doubleJumpOk = true;
    private int jumpsAvailable = 2;
    private int jumpsMax = 2;
    private bool isJumping = false;
   [SerializeField]
    public CharacterController cc;

    void Start()
    {

        float timetoApex = jumpTime / 2.0f;
        gravity = (-2 * jumpHeight) / Mathf.Pow(timetoApex, 2);

        initialjumpVelocity = (2 * jumpHeight) / timetoApex;

        jumpsAvailable = jumpsMax;
       
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movement = transform.TransformDirection(movement);
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        movement *= speed;

        yVelocity += gravity * Time.deltaTime;
        if (cc.isGrounded && yVelocity < 0.0)
        {
            isJumping = false;
            yVelocity = yVelocityGrounded;
            jumpsAvailable = jumpsMax;
            //doubleJumpOk = 2;
        }

        //falling!
        if (!cc.isGrounded && !isJumping)
        {
            jumpsAvailable = 1;
        }

        if (Input.GetButtonDown("Jump") && jumpsAvailable > 0 )
        {
            isJumping = true;
            yVelocity = initialjumpVelocity;
            jumpsAvailable--; 
            

        }
     

        //if (Input.GetButtonDown("Jump") && cc.isGrounded)
        //{
        //    yVelocity = initialjumpVelocity;
        //    //jumpsAvailable--; 
        //    //doubleJumpOk = true;

        //}else {
        //    if(doubleJumpOk && Input.GetButtonDown("Jump")){
        //        doubleJumpOk = false;
        //        yVelocity = initialjumpVelocity;
        //    }
        //}

        movement.y = yVelocity;
        cc.Move(movement * Time.deltaTime);

        Vector3 rotation = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        //transform.Rotate(rotation * Time.deltaTime * rotSpeed);
         transform.Rotate(rotation * speed);
    }
}
