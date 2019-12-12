using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBallComponent : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Use for initializing physics components
    void FixedUpdate()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveHor, 0.0f, moveVert);

        rb.AddForce(move * speed);
    }
}
