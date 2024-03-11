using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        // Get the Rigidbody2D componet attached to the Gameobject
        rb = GetComponent<Rigidbody2D>();   
    }
    // Update is called once per frame
    void Update()
    {
        //Get input values for horizontal and vertical movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();
    }

    void FixedUpdate()
    {
        //Move the player using Rigidbody2D in FixedUpdate
        rb.velocity = new Vector2(movement.x*moveSpeed, movement.y*moveSpeed);
    }
}
