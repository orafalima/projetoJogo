using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    private float horizontalMovement = 0f;

    private bool isJumping = false;

    [SerializeField]
    private float speed = 40f;

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime, false, isJumping);
        isJumping = false;
    }

}
