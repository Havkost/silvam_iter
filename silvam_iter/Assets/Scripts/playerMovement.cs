using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;

    public float movementspeed = 12f;
    public float gravity = -20f;
    public float jumpHeight = 5f;
    public int maxJumps = 1;
    int jumps = 0;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // Check if grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Reset fall speed
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            jumps = maxJumps + showCollected.collectedOrbs;
        }

        // Get input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * movementspeed * Time.deltaTime);

        // Jump
        if (Input.GetButtonDown("Jump") && jumps > 0)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumps -= 1;
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;

        // Move player
        controller.Move(velocity * Time.deltaTime);
    }
}
