using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Reference to the RigidBody component called "rb"
    public Rigidbody2D rb;

    // Reference to animator
    public Animator animator;

    //Determining if the player is grounded
    
    [SerializeField] private LayerMask WhatIsGround;  // Create a mask to determine what is classed as ground to the player
    [SerializeField] private Transform OnGroundCheck;// A position marking where to check if the player is grounded
    const float GroundedRadius = 0.2f; // Radius of overlapping circles to determine if player is on the ground
    private bool Grounded; // is the player grounded
    private bool FacingRight = true; // Determine which way player is facing

    public float SidewaysForce = 2000f;
    public float JumpForce = 10000f;
    public float JumpTime; // Maximum time of jump
    private float JumpTimeCounter; // How many times is the force applied
    private bool IsJumping; // Is the player already jumping

    private void FixedUpdate()
    {
        // Check to see if player is grounded using colliders
        bool WasGrounded = Grounded;
        Grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(OnGroundCheck.position, GroundedRadius, WhatIsGround);
        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                Grounded = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Animation parameters when idle on ground
        animator.SetFloat("Speed", 0);

        if (Grounded == false)
        {
            animator.SetFloat("Speed", 0);
            animator.SetFloat("Jump", 1);
        }    
        else

        {
           animator.SetFloat("Speed", 0);
           animator.SetFloat("Jump", 0);
        }
        

        //Add a sidewaysforce
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * SidewaysForce * Time.deltaTime);

            if(Grounded == true)
            {
                animator.SetFloat("Speed", 1);
                animator.SetFloat("Jump", 0);
            }
           
           
            if (FacingRight != true)
            {
                FlipPlayer();
            }
        }

        if (Input.GetKey(KeyCode.A))
        { 
            rb.AddForce(Vector2.left * SidewaysForce * Time.deltaTime);

            if (Grounded == true)
            {
                animator.SetFloat("Speed", 1);
                animator.SetFloat("Jump", 0);
            }

            if (FacingRight != false)
            {
                FlipPlayer();
            }
        }

        //Add a force to initiate a Jump
        if (Input.GetKey(KeyCode.Space) && Grounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            animator.SetFloat("Speed", 0);
            IsJumping = true;
            JumpTimeCounter = JumpTime;
            
        }

        JumpTimeCounter -= Time.deltaTime;

        // Parameters to determine the length of the initial jump
        if (IsJumping== true && Input.GetKey(KeyCode.Space))
        {
            if (JumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            }
            else if (JumpTimeCounter < 0)
            {
                IsJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            IsJumping = false;
        }

        // Parameters to determine if player is on a one way platform and can jump down
        if (Grounded == true && gameObject.layer != 10)
        {
            gameObject.layer = 10;  
        }
            
       if (Grounded == true && Input.GetKey(KeyCode.S))
        {
            gameObject.layer = 11;
        }
    }

    private void FlipPlayer()
    {
        //Switch whether player labelled as facing right or left
        FacingRight = !FacingRight;

        // Multiply the players local scale by -1 in order to make the player face left
        Vector3 TheScale = transform.localScale;
        TheScale.x *= -1;
        transform.localScale = TheScale;
    }
}

