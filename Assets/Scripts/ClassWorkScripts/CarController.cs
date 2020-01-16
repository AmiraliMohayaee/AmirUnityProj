using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 30.0f)]
    private float m_moveSpeed = 5.0f;
    [SerializeField]
    [Range(0.1f, 30.0f)]
    private float m_turnSpeed = 1.0f;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * m_moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles += new Vector3(0.0f, -m_turnSpeed, 0.0f) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * m_moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += new Vector3(0.0f, m_turnSpeed, 0.0f) * Time.deltaTime;
        }
    }
}
