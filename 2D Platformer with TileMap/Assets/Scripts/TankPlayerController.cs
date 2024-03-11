using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayerController : MonoBehaviour
{
    
    public float speed;

    public float turnSpeed;

    public float horizontalInput;
    public float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get Input - Do this in Update()
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Move Player forward with vertical Input
        transform.Translate(Vector2.right * Time.deltaTime * speed * verticalInput);

        //Rotate player with horizontal Input
        transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime * horizontalInput);
    }
}
