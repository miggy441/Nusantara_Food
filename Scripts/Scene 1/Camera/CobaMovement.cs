using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobaMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private CharacterController controller;
    private Vector3 moveDirection;
    private Vector3 velocity;
    public GameObject togglekey;
    //private float rotationX = 0;
    //private float rotationY = 0;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    //[SerializeField] private float lookSpeed = 2f;
    //[SerializeField] private float lookXLimit = 45f;
    //public Camera playerCamera;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        move();
    }

    private void move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        float moveZ = Input.GetAxis("Horizontal");

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection *= speed;

        Vector3 move = transform.right * moveZ;

        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //rotationY -= Input.GetAxis("Mouse X") * lookSpeed;
        //rotationX += Input.GetAxis("Mouse Y") * lookSpeed;

        
        //rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        //playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        //transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }

    public void buttonClicked()
    {
        if (togglekey.activeInHierarchy == true && Input.GetKeyDown(KeyCode.Space))
        {
            togglekey.SetActive(false);

        }
        else
        {
            togglekey.SetActive(true);
        }
    }
}
