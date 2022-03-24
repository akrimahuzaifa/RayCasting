using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    float mouseX;
    float mouseY;
    float mouseSensivity = 5f;

    //public Transform playerBody;

    //float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseSensivity;
        mouseY += Input.GetAxis("Mouse Y") * mouseSensivity;

        /*        xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f);

                transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

                playerBody.Rotate(Vector3.up * mouseX);*/

        float upRotationLimit = Mathf.Clamp(mouseY, -90, 90);
        transform.localEulerAngles = new Vector3(-upRotationLimit, mouseX, 0f);
    }
}
