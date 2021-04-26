using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    // Enum with directions
    public enum Direction
    {
        Left,
        Right
    }

    [Range(0, 30)] public float speed = 15; // speed of the running
    public Direction direction = Direction.Right; // direction which the player is going
    public int maxJumps = 2; // maximum jumps player can use
    private int jumpCount = 0; // how many jumps player has already used

    private Rigidbody2D p_RigidBody2D = null; // player rigid body
    private Vector3 p_velocity = Vector3.zero; // player velocity

    private bool isGrounded = false; // if player is on the ground/plaform
    private GameObject platform; // what platform player is colliding with

    // Force attributes (jump and dashes)
    public float jumpForce = 10;
    public float upDashForce = 10;
    public float downDashForce = 10;
    public float rightDashForce = 10;

    // Dash attributtes
    private bool canDash = true;
    private float dashCooldown = 5f;
    private float dashTimePassed = 0;

    private void Awake()
    {
        p_RigidBody2D = GetComponent<Rigidbody2D>();
        dashTimePassed = dashCooldown;
    }

    void FixedUpdate()
    {
        // Automatic running
        float movement = speed * Time.fixedDeltaTime;
        Vector3 targetVelocity = Vector2.zero;

<<<<<<< Updated upstream
    private float horizontalMovement = 0f;
=======
        if (direction == Direction.Right)
            targetVelocity = new Vector2(movement * 10f, p_RigidBody2D.velocity.y);
        
        if (direction == Direction.Left)
            targetVelocity = new Vector2(-(movement * 10f), p_RigidBody2D.velocity.y);
>>>>>>> Stashed changes

        p_RigidBody2D.velocity = Vector3.SmoothDamp(p_RigidBody2D.velocity, targetVelocity, ref p_velocity, 0.05f);

        // Dash cooldown
        if (dashTimePassed < dashCooldown)
        {
            dashTimePassed += Time.fixedDeltaTime;
            canDash = false;
        }
        else
        {
            dashTimePassed = dashCooldown;
            canDash = true;
        }
    }

    [SerializeField]
    private float speed = 40f;

    private void Update()
    {
<<<<<<< Updated upstream
        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButtonDown("Jump"))
=======
        float gravityDelay = 0.3f;

        // Jump movement
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (jumpCount < maxJumps)
            {
                Debug.Log("Jump!");
                p_RigidBody2D.velocity = Vector2.up * jumpForce;
                jumpCount++;
            }
        }

        // Fall movement
        if (Input.GetKeyDown(KeyCode.DownArrow))
>>>>>>> Stashed changes
        {
            if (platform != null)
            {
                Debug.Log("Fall!");
                platform.GetComponent<EdgeCollider2D>().enabled = false;
            }
        }

        // Up dash movement
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (canDash && !isGrounded)
            {
                Debug.Log("Up Dash!");
                p_RigidBody2D.velocity = Vector2.up * upDashForce;
                dashTimePassed = 0;
            }
        }

        // Down dash movement
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (canDash && !isGrounded)
            {
                Debug.Log("Down Dash!");
                p_RigidBody2D.gravityScale = 0;
                p_RigidBody2D.velocity = Vector2.down * downDashForce;
                dashTimePassed = 0;
                StartCoroutine(PauseGravity(gravityDelay));
            }
        }

        // Right dash movement
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (canDash && !isGrounded)
            {
                Debug.Log("Right Dash!");
                p_RigidBody2D.gravityScale = 0;
                p_RigidBody2D.velocity = Vector2.right * rightDashForce;
                dashTimePassed = 0;
                StartCoroutine(PauseGravity(gravityDelay));
            }
        }
    }

    IEnumerator PauseGravity(float gravityDelay)
    {
        yield return new WaitForSeconds(gravityDelay);
        p_RigidBody2D.gravityScale = 2;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
<<<<<<< Updated upstream
        controller.Move(horizontalMovement * Time.fixedDeltaTime, false, isJumping);
        isJumping = false;
=======
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jumpCount = 0;
        }

        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
            jumpCount = 0;
            platform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }

        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = false;
            platform = null;
        }
>>>>>>> Stashed changes
    }

}
