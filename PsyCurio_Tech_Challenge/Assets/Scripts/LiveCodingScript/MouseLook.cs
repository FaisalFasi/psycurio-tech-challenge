using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    // default mouse senstivity you can change it in the inspector according to your needs
    public float mouseSensitivity = 100f;
    // getting player transforms 
    public Transform playerBody;
    // player rotation x
    float XRotation = 25f;

    // Start is called before the first frame update
    void Start()
    {
        //Looking the cursor in the game scene
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        // getting x-axis and y-axis inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity *  Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        XRotation -= mouseY;
 
        // limit of camera movement in y direction
        XRotation = Mathf.Clamp(XRotation, -90f,90f);

        // rotating the camera
        transform.localRotation = Quaternion.Euler(XRotation,0,0);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
