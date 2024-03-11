using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f; 

    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalInput;

    [SerializeField] private AudioClip jumpSoundClip;
    // Start is called before the first frame update
    void Start()
    {
        //Get the Rigidbody2D component attached to the GameObject
        rb = GetComponent<Rigidbody2D>();

        //Ensure the groundCheck variable is assigned
        if ( groundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to the player controller!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Get input values for horizontal movement
        horizontalInput = Input.GetAxis("Horizontal");

        //Check for jump input
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //Apply an upward force for jumping
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            SoundFXManager.instance.PlaySoundFXCLip(jumpSoundClip,transform, 1f);
            
        }
        
    }

    private void FixedUpdate()
    {
        //Move the player using Rigidbody2D in FixedUpdate
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        //Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //Optionally, you can add animations or other behavior here based on player state
        if(horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // Facing right
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // Facing Left
        }
       
    }
}
