using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MouseSesnsitivity = 150f;
    
    public Transform PlayerHead;
    public Camera Cam;

    public float VertMinAngle =-90f;
    public float VertMaxAngle = 90f;

    float RotationX = 0f; 
    float RotationY = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Get mouse move then multiply by MouseSens and 
        float MouseX = Input.GetAxis("Mouse X") * MouseSesnsitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSesnsitivity * Time.deltaTime;
        
        //Change Rotation
        RotationX -= MouseY;
        //"+" because with "-" direction reversed
        RotationY += MouseX;

        //lock vert Rotation
        RotationX =Mathf.Clamp(RotationX,VertMinAngle,VertMaxAngle);

        //Rotate Camera
        Cam.transform.localRotation = Quaternion.Euler(RotationX, RotationY, 0f);
        //Rotate Head (Visual)
        PlayerHead.Rotate(Vector3.up * MouseX);
    }
}
