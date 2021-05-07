using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Controller
    private bool PlayerHasControl { get; set; }

    // Physics
    private enum yMovement { Falling, Rising, Idle }
    private yMovement yDirection;
    private Rigidbody2D p_RigidBody2D = null; // player rigid body
    private Vector3 p_velocity = Vector3.zero; // player velocity
    public float gravityDelay = 0.3f; // player gravity delay

    // Physics Method Call Flag
    private bool jump = false;
    private bool lateralDash = false;
    private bool upDash = false;
    private bool downDash = false;

    // Running Attributes
    public enum Direction { Right, Left }
    public Direction direction = Direction.Right; // direction which the player is going
    public bool running = false; // toggle running state
    [Range(0, 60)] public float speed = 15; // speed of the running

    // Jumping and Grounding
    public int maxJumps = 2; // maximum jumps player can use
    public int jumpCount = 0; // how many jumps player has already used
    public float jumpForce = 10; // force of jump
    private bool isGrounded = false; // if player is on the ground/plaform
    private float airTime; // to control landing animation
    private GameObject platform { get; set; } // what platform player is colliding with

    // Dash attributtes
    private bool canDash = true;
    private float dashTimePassed = 0; // counter for Dash Recharge
    public float dashCooldown = 2f;
    public float upDashForce = 13;
    public float downDashForce = 20;
    public float rightDashForce = 10;

    // Cape Attributes
    public CapeController cape;

    // Audio Controller
    private PlayerAudio playerAudio;

    // Animation & Sprites Controller
    private Animator animator;
    private SpriteRenderer sprites;

    private void Awake()
    {
        PlayerHasControl = true;

        // Getting Object References
        p_RigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprites = GetComponent<SpriteRenderer>();
        playerAudio = GetComponent<PlayerAudio>();

        // Setting Initial Attributes
        running = true; // WARNING: ALL TO 'FALSE' ON GAMEBUILD
        animator.SetBool("running", true);
        cape.HasCape = true;
        cape.Running = true;
        // animator.SetBool("running", true);

        dashTimePassed = dashCooldown;
    }

    void FixedUpdate()
    {
        // Y velocity
        YVelocity();

        // Automatic running
        float movement = speed * Time.fixedDeltaTime;
        Vector3 targetVelocity = Vector2.zero;

        if (running)
        {
            if (direction == Direction.Right)
            {
                targetVelocity = new Vector2(movement * 10f, p_RigidBody2D.velocity.y);
                sprites.flipX = false;
            }

            if (direction == Direction.Left)
            {
                targetVelocity = new Vector2(-(movement * 10f), p_RigidBody2D.velocity.y);
                sprites.flipX = true;
            }
        }
        else
        {
            cape.Running = false;
        }

        p_RigidBody2D.velocity = Vector3.SmoothDamp(p_RigidBody2D.velocity, targetVelocity, ref p_velocity, 0.05f);

        // Dash cooldown
        if (dashTimePassed < dashCooldown)
        {
            dashTimePassed += Time.fixedDeltaTime;
            canDash = false;
            cape.CanDash = false;
            animator.SetBool("lateralDash", false);
            animator.SetBool("upDash", false);
            animator.SetBool("downDash", false);
        }
        else
        {
            dashTimePassed = dashCooldown;
            canDash = true;
            cape.CanDash = true;
        }

        // Airtime Counter
        if (!isGrounded)
        {
            airTime += Time.fixedDeltaTime;
        }

        // Grounding Check
        if (isGrounded && yDirection != yMovement.Rising)
        {
            // Animation Cycle
            animator.SetBool("isGrounded", true);
            animator.SetBool("jump1", false);
            animator.SetBool("jump2", false);

            cape.IsGrounded = true;
            cape.Jump1 = true;
            cape.Jump2 = true;

            if (airTime > 1.5)
            {
                animator.SetBool("hardLanding", true);
                cape.HardLanding = true;
            }
            else if (airTime > 0.05 && airTime <= 1.5)
            {
                animator.SetBool("softLanding", true);
                cape.SoftLanding = true;
            }
            StartCoroutine(AnimationReload());

            jumpCount = 0;
            airTime = 0;
        }
        else
        {
            // Animation Cycle
            animator.SetBool("isGrounded", false);
        }

        // Controller Physics Execution
        if (jump)
        {
            p_RigidBody2D.velocity = new Vector2(p_RigidBody2D.velocity.x, jumpForce);
            jump = false;
        }
        if (lateralDash)
        {
            p_RigidBody2D.gravityScale = 0;
            p_RigidBody2D.velocity = new Vector2(rightDashForce, 0);
            StartCoroutine(PauseGravity());

            lateralDash = false;
        }
        if (downDash)
        {
            StartCoroutine(PauseSpeed(.3f, speed));

            p_RigidBody2D.gravityScale = 0;
            p_RigidBody2D.velocity = new Vector2(p_RigidBody2D.velocity.x, -downDashForce);
            StartCoroutine(PauseGravity());

            downDash = false;
        }
        if (upDash)
        {
            p_RigidBody2D.velocity = new Vector2(p_RigidBody2D.velocity.x, upDashForce);
            upDash = false;
        }

    }

    private void YVelocity()
    {
        if (p_RigidBody2D.velocity.y > 6)
        {
            yDirection = yMovement.Rising;

        }
        else if (p_RigidBody2D.velocity.y < -6)
        {
            yDirection = yMovement.Falling;
        }
        else if (p_RigidBody2D.velocity.y == 0 && isGrounded)
        {
            yDirection = yMovement.Idle;
        }
    }

    private void Update()
    {
        // Inputs
        if (PlayerHasControl)
        {
            // Jump movement
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (jumpCount < maxJumps)
                    Jump();
            }

            // Drop movement
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Drop();
            }

            // Up dash movement
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (canDash && !isGrounded)
                    UpDash();
            }

            // Down dash movement
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (canDash && !isGrounded)
                    DownDash();
            }

            // Right dash movement
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (canDash && !isGrounded)
                    LateralDash();
            }
        }

        //FallingOrRising();
        Debug.Log(yDirection);
    }

    private void Jump()
    {
        // Animation Cycle
        if (jumpCount == 1)
        {
            animator.SetBool("jump2", true);
        }
        else
        {
            animator.SetBool("jump1", true);
        }
        StartCoroutine(AnimationReload());

        // Audio Cycle
        playerAudio.PlayJumpAudio();

        // Logic Cycle
        jumpCount++;

        // Physics Cycle
        jump = true;
    }

    private void Drop()
    {
        animator.SetBool("dropping", true);
        StartCoroutine(AnimationReload());
        
        if (platform != null)
            platform.GetComponent<EdgeCollider2D>().enabled = false;
    }

    private void LateralDash()
    {
        // Animation Cycle
        animator.SetBool("lateralDash", true);
        cape.LateralDash = true;
        cape.CanDash = false;
        StartCoroutine(AnimationReload());

        // Audio Cycle
        playerAudio.PlayDashAudio();

        // Logic Cycle
        dashTimePassed = 0;

        // Physics Cycle
        lateralDash = true;
    }

    private void DownDash()
    {
        // Animation Cycle
        animator.SetBool("downDash", true);
        animator.SetBool("hardLanding", true);
        cape.DownDash = true;
        cape.CanDash = false;
        StartCoroutine(AnimationReload());

        // Audio Cycle
        playerAudio.PlayDashAudio();

        // Logic Cycle
        dashTimePassed = 0;
        airTime += 1.5f; // deixar aqui ou não funciona!

        // Physics Cycle
        downDash = true;
    }

    private void UpDash()
    {
        // Animation Cycle
        animator.SetBool("upDash", true);
        cape.UpDash = true;
        cape.CanDash = false;
        StartCoroutine(AnimationReload());

        // Audio Cycle
        playerAudio.PlayDashAudio();

        // Logic Cycle
        dashTimePassed = 0;

        // Physics Cycle
        upDash = true;
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    IEnumerator AnimationReload()
    {
        yield return 0;

        animator.SetBool("jump1", false);
        animator.SetBool("jump2", false);
        animator.SetBool("lateralDash", false);
        animator.SetBool("upDash", false);
        animator.SetBool("downDash", false);
        animator.SetBool("hardLanding", false);
        animator.SetBool("softLanding", false);
        animator.SetBool("dropping", false);

        cape.Jump1 = false;
        cape.Jump2 = false;
        cape.UpDash = false;
        cape.DownDash = false;
        cape.LateralDash = false;
    }

    IEnumerator PauseGravity()
    {
        yield return new WaitForSeconds(gravityDelay);
        p_RigidBody2D.gravityScale = 2;
    }

    IEnumerator PauseSpeed(float speedDelay, float currentSpeed)
    {
        speed = 0;
        yield return new WaitForSeconds(speedDelay);
        speed = currentSpeed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "Platform")
        {
            platform = collision.gameObject;
            isGrounded = true;
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
            platform = null;
            isGrounded = false;
        }
    }
}
