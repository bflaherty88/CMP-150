using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class CharacterControl : MonoBehaviour
{
    CharacterController controller;

    public float moveSpeed = 5f;
    public float jumpHeight = 8f;
    public float jumpBoost = 1.5f;
    public float gravity = 20f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpHeight;
                moveDirection.x *= jumpBoost;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

}
