using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestCamera : MonoBehaviour
{
    public KeyLockCamera check;

    float rotationX = 0f;
    float rotationY = 0f;

    public float sensitivity = 5f;

    private void Update()
    {
        if (check.lockCursor == true)
        {
            rotationY += Input.GetAxis("Mouse X") * sensitivity;
            rotationX += -Input.GetAxis("Mouse Y") * sensitivity;

            rotationX = Mathf.Clamp(rotationX, -25f, 25f);
            rotationY = Mathf.Clamp(rotationY, -30f, 30f);

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
        
    }

    void cameraMovement()
    {
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += -Input.GetAxis("Mouse Y") * sensitivity;

        rotationX = Mathf.Clamp(rotationX, -25f, 25f);
        rotationY = Mathf.Clamp(rotationY, -30f, 30f);

        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}
