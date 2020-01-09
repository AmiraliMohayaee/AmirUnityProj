using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSenseitivity = 100.0f;

    public Transform playerBody;

    private float xRot = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Ensuring to not accidentally click out of the application
        // especially in windowed mode
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") 
            * mouseSenseitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") 
            * mouseSenseitivity * Time.deltaTime;

        // Applying a clamp on Y-axis to not over-rotate unnaturally
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        // Rotates player character's body on X-axis
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
