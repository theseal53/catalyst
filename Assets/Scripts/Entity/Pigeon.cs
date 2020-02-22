using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : Entity
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity =1.0f;

    private Vector3 forward = Vector3.zero;
    private Vector3 movement = Vector3.zero;

    private Vector3 moveDirection = Vector3.zero;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            movement = (moveVertical * forward + moveHorizontal * Camera.main.transform.right).normalized;

            movement *= speed;

            // Move the controller
            controller.Move(movement * Time.deltaTime);
        } else
        {
            Vector3 movement = new Vector3(0, 0, 0);
            if (!controller.isGrounded)
            {
                movement.y = movement.y - gravity;
                controller.Move(movement);
            }
        }
    }
}
