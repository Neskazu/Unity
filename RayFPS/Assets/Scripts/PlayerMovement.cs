using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float MoveSpeed = 5;
    public float ShiftSpeed = 7.5f;
    public GameObject Cam;
    public Rigidbody RB;
    bool isShift;
    Vector3 movement;
    Vector3 rotatedDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get movement then normalize it to remove extra speed
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;


        //Rotate direction vector with the camera
        rotatedDir = Cam.transform.TransformDirection(movement);
        rotatedDir = new Vector3(rotatedDir.x, 0, rotatedDir.z);
        rotatedDir = rotatedDir.normalized * movement.magnitude;
        if (Input.GetKeyDown("left shift"))
        {
            isShift = true;
        }
        if (Input.GetKeyUp("left shift"))
        {
            isShift = false;
        }
    }
        void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        if (isShift)
        {
            RB.MovePosition(RB.transform.position + rotatedDir * ShiftSpeed);
        }
        else
        {
            RB.MovePosition(RB.transform.position + rotatedDir * MoveSpeed);
        }
    }
}
