using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float movespeed = 2f;

    public Rigidbody2D rb;

    Vector2 movement;

    bool isMoveRight=true;

    bool isGameStart;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isGameStart = true;
        }
        if (isGameStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isMoveRight = !isMoveRight;
            }
        }
    }
    void FixedUpdate()
    {
       if (isGameStart)
        {
        Move();
        }
    }
    void Move()
    {//Movement
        if (isMoveRight)
        {

            rb.MovePosition(rb.position + Vector2.right * movespeed * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + Vector2.up * movespeed * Time.fixedDeltaTime);
        }
    }
}
