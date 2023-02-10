using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public Transform orientation;

    private Animator Door;

    float horizontalInput;
    float verticalInput;

    private Rigidbody rb;

    Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Door = GetComponent<Animator>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInput(); 
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 1f, ForceMode.Force);
    }

    private void OnTriggerEnter()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Door.SetTrigger("Opened?");
        }
    }
}
