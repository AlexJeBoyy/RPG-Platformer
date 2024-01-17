using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RBPlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float runningSpeed;
    private float currentSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;

    public float climbSpeed;
    public bool climbing;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;


    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    public Climbing climbingScript;
   
   
    
  

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        currentSpeed = moveSpeed;

        Physics.gravity = new Vector3(0, -30f, 0);

    }
    private void Update()
    {
        //checks if grounded
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

       
        MyInput();
        SpeedControl();

        //handle drag
        if (climbing)
        {
            moveSpeed = climbSpeed;
        } 
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runningSpeed;
        }
        else
        {
            moveSpeed = currentSpeed;
        }


        //Freeze things with grapling hook

       


    }

    private void FixedUpdate() //called before an update
    {
        MovePlayer();
    }
    private void MyInput() //get the input
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {

            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }


    }

    private void MovePlayer() //moves the player
    {
       if (climbingScript.exitingWall) return;

        //calculates movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //on ground
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        }
        //in air
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()//handles the speed whit the grapple
    {
       
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

    }
    private void Jump()
    {
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

    }
    private void ResetJump()
    {
        readyToJump = true;
    }

    

    private Vector3 velocityToSet;
    private void SetVelocity()
    {
        
        rb.velocity = velocityToSet;
    }


    public void OnCollisionEnter(Collision collision)
    {
        //if ()
        //{

        //}
    }

}

   
