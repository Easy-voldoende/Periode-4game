using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 movement;
    public float horizontal;
    public float vertical;
    public float walkSpeed;
    public float sprintSpeed;
    public float crouchSpeed;
    public bool isSprinting;
    public bool isWalking;
    public bool isCrouching;
    public Transform cam;
    public bool crouchToggle;
    public bool standingStill;
    public bool isGrounded;
    public Vector3 jumpPower;

    //rotation
    public float sensitivity = 200f;
    public Transform playerBody;
    float xRotation = 0f;

    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody3D>();
        crouchSpeed = 2f;
        walkSpeed = 5f;
        sprintSpeed = 10f;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        movement.x = horizontal;
        vertical = Input.GetAxis("Vertical");
        movement.z = vertical;
        transform.Translate(movement * walkSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
            isWalking = false;
            walkSpeed = 12f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
            isWalking = true;
            walkSpeed = 5f;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            isCrouching = true;
            walkSpeed = crouchSpeed;
        }
        else
        {
            isCrouching = false;
            if (isCrouching == false)
            {
                if (isSprinting == false)
                {
                    walkSpeed = 5f;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (crouchToggle == false)
            {
                crouchToggle = true;
                transform.localScale -= new Vector3(0f, 0.60f, 0f);
                transform.localPosition -= new Vector3(0f, 0.30f, 0f);
            }

        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouchToggle = false;
            transform.localScale += new Vector3(0f, 0.60f, 0f);
            transform.localPosition += new Vector3(0f, 0.30f, 0f);
        }
       



    }


    void Awake()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded == true)
            {
                isGrounded = false;
                GetComponent<Rigidbody>().velocity += jumpPower;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }

    }

}

