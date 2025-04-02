using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region variable declaration
    [SerializeField] private float topSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallingGravityMultiplier;
    [SerializeField] private float gravityScale;
    [SerializeField] private float terminalVelocity;
    [SerializeField] private float airControllTime;
    [SerializeField] private float apoapsisGravityMultiplier;
    [SerializeField] private float midairAccelMultipiler;
    private Rigidbody2D myRb;
    //private Animator animator;
    private bool jumpRising, updatedJump = false;
    [SerializeField] private bool canJump = true, canMove = true, acceptInput = true;
    private float updatedHorizontal, targetSpeed;
    [SerializeField] private float coyoteTime, jumpBuffer;
    private float coyoteTimeTimer, jumpBufferTimer = 0f;
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (acceptInput)
        {
            updatedHorizontal = Input.GetAxis("Horizontal");

            if (IsGrounded()) coyoteTimeTimer = coyoteTime;
            else coyoteTimeTimer -= Time.deltaTime;

            if (Input.GetButtonDown("Jump")) jumpBufferTimer = jumpBuffer;
            else jumpBufferTimer -= Time.deltaTime;

            if (Input.GetButtonDown("Jump")) updatedJump = true;
            if (Input.GetButtonUp("Jump")) updatedJump = false;
        }

        //if (IsGrounded() && updatedHorizontal != 0f) animator.SetBool("isWalking", true);
        //else if (IsGrounded()) animator.SetBool("isWalking", false);
    }

    private void FixedUpdate()
    {

        Debug.Log(IsGrounded() +" " + jumpRising + " " + canJump);
        #region Movement
        if (canMove)
        {
            // Acceleration and Deceleration (new)
            float targetSpeed = updatedHorizontal * topSpeed;
            float deltaV = targetSpeed - myRb.linearVelocity.x;

            // checks if player is accelerating or declerating
            float accelerationRate = (Mathf.Abs(targetSpeed) > Mathf.Abs(myRb.linearVelocity.x) && (Mathf.Sign(targetSpeed) == Mathf.Sign(myRb.linearVelocity.x) || myRb.linearVelocity.x == 0f)) ? acceleration : deceleration;
            accelerationRate = IsGrounded() ? accelerationRate : accelerationRate * midairAccelMultipiler;

            // applying force
            myRb.AddForce(deltaV * accelerationRate * Vector2.right);

            // flipping
            if (targetSpeed < 0f) gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
            else if (targetSpeed > 0f) gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
            // Jumping (new)
            if (jumpBufferTimer > 0f && coyoteTimeTimer > 0f && canJump && !jumpRising)
            {
                //animator.SetTrigger("Jump");
                myRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpRising = true;
                coyoteTimeTimer = 0f;
                jumpBufferTimer = 0f;
            }
            // Detects when first stage of jump is complete or cut short by collision
            if (jumpRising && !updatedJump || myRb.linearVelocity.y < 0f)
            {
                jumpRising = false;
            }

            // Player character's gravity is multiplied when falling for more dynamic effect
            if (!IsGrounded())
            {
                //animator.SetBool("Falling", true);
                if (Mathf.Abs(myRb.linearVelocity.y) < airControllTime)
                    myRb.gravityScale = gravityScale * apoapsisGravityMultiplier;
                else if (myRb.linearVelocity.y < 0 || jumpRising == false)
                    myRb.gravityScale = gravityScale * fallingGravityMultiplier;
            }
            else
            {
                myRb.gravityScale = gravityScale;
                //animator.SetBool("Falling", false);
            }

            // Terminal Velocity
            if (Mathf.Abs(myRb.linearVelocity.y) > terminalVelocity)
                myRb.linearVelocity = new Vector2(myRb.linearVelocity.x, -terminalVelocity);
        }
        else myRb.linearVelocity = Vector2.zero;
        #endregion

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, new Vector2(0.2f, 0.1f), 0f, LayerMask.GetMask("Ground"));
    }

    private void OnDrawGizmos()
    {
        // Draws circle gizomo on groundCheck game object
        Gizmos.DrawWireCube(groundCheck.position, new Vector2(0.2f, 0.1f));
    }

}
