using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Test test
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardSpeed = Input.GetAxis("Vertical");
        

        transform.Translate(Vector3.forward * Time.deltaTime *
           speed * forwardSpeed);
        transform.Rotate(Vector3.up, 
            Time.deltaTime * turnSpeed * horizontalInput);
    }
}
