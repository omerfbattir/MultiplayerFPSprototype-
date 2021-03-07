using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float     mouseSensivity = 50f;
    [SerializeField] private float     speed = 12f;
    [SerializeField] private float     jumpH = 3f;
    [SerializeField] private float     groundDistance;
    [SerializeField] private Transform playerCam;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    

    private CharacterController controller;
    private float xRotation=1f;
    
    private Vector3 velocity;
    private bool isGrounded;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        controller = GetComponent<CharacterController>();
    }
    
    void FixedUpdate()
    {
        Movement();
        Looking();
    }

    void Movement()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * xMove + transform.forward * yMove;
        move = move * speed * Time.fixedDeltaTime;
        
        controller.Move(move);
        
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpH * -2f * Physics.gravity.y);
        }

        velocity.y += Physics.gravity.y * Time.fixedDeltaTime;
        controller.Move(velocity*Time.fixedDeltaTime);

    }

    void Looking()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.fixedDeltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        
        playerCam.transform.localRotation = Quaternion.Euler(xRotation,0,0);
        transform.Rotate(Vector3.up, mouseX);
    }
}
