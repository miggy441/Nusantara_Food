using UnityEngine;
using System.Collections;

public class KeyLockCamera : MonoBehaviour
{

    public bool lockCursor = true;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            lockCursor = !lockCursor;
        }

        Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !lockCursor;
    }
}