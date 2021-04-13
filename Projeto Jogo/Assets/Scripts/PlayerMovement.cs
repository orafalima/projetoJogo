using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float speed = 1f;

    private bool isJumping = false;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(speed * Time.fixedDeltaTime, false, isJumping);
        isJumping = false;
    }

}
