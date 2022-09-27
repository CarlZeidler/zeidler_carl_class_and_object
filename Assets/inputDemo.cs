using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputDemo : ProcessingLite.GP21
{
    private Vector2 circlePos;
    private Vector2 playerTwoCirclePos;
    private float velocity = 3f;
    private float velocity2 = 2f;
    private float acceleration = 3f;
    public float speedLimit = 8f;
    private float circleDiam = 1f;
    private bool gravityActive = false;
    private float axisHorizontal;
    private float axisVertical;
    private float friction = 3;
    private float gravity;
    private Vector2 axisInput;

    void Friction ()
    {

    }

    void Start()
    {
        Application.targetFrameRate = 60;
        Background(140);
        circlePos = new Vector2(1, 4);
        playerTwoCirclePos = new Vector2(1, 1);
    }

    void Update()
    {
        //Paint the scene every frame
        Background(140);
        Circle(circlePos.x, circlePos.y, circleDiam);
        Circle(playerTwoCirclePos.x, playerTwoCirclePos.y, circleDiam);

        //Reset speed
        //velocity = 2f;

        //
        ////Basic movement with WASD
        //
        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        //{
        //    if (Input.GetKey(KeyCode.D))
        //    {
        //        circlePos.x += velocity * Time.deltaTime;
        //    }
        //    else
        //    {
        //        circlePos.x -= velocity * Time.deltaTime;
        //    }
        //}

        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        //{
        //    if (Input.GetKey(KeyCode.W))
        //    {
        //        circlePos.y += velocity * Time.deltaTime;
        //    }
        //    else
        //    {
        //        circlePos.y -= velocity * Time.deltaTime;
        //    }
        //}

        //
        ////Acceleration for second circle
        //
        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        //{
        //    velocity2 += acceleration;
        //    if (Input.GetKey(KeyCode.D))
        //    {
        //        playerTwoCirclePos.x += velocity2 * Time.deltaTime;
        //    }
        //    else
        //    {
        //        playerTwoCirclePos.x -= velocity2 * Time.deltaTime;
        //    }

        //    //Limits top speed
        //    if (velocity2 >= 5)
        //    {
        //        velocity2 = 5;
        //    }
        //}

        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        //{
        //    velocity2 += acceleration * time.Deltatime;
        //    if (Input.GetKey(KeyCode.W))
        //    {
        //        playerTwoCirclePos.y += velocity2 * Time.deltaTime;
        //    }
        //    else
        //    {
        //        playerTwoCirclePos.y -= velocity2 * Time.deltaTime;
        //    }

        //    //Limits top speed
        //    if (velocity2 >=  5)
        //    {
        //        velocity2 = 5;
        //    }
        //}
       
        //
        //Smooth acceleration and deceleration
        //
        //Checks if any axis button is pressed
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float axisCheck = Mathf.Abs(x) + Mathf.Abs(y);

        //My original solution
        //if (Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") != 0)

        if (Input.GetKeyDown(KeyCode.G))
        {
            gravityActive = !gravityActive;
        }

        if (gravityActive == true)
        {
            gravity = -1;
        }
        else
        {
            gravity = 0;
        }

        if (axisCheck != 0) 
        {
            axisHorizontal = Input.GetAxisRaw("Horizontal");
            axisVertical = Input.GetAxisRaw("Vertical");
            axisInput = new Vector2(axisHorizontal, axisVertical).normalized;

            velocity += acceleration * Time.deltaTime;

            circlePos += axisInput * velocity * Time.deltaTime;
            //circlePos.y += axisInput.y * velocity * Time.deltaTime;
            
            //Limit speed
            if (velocity >= speedLimit)
            {
                velocity = speedLimit;
            }
        }
        else if (axisCheck == 0)
        {
            velocity -= friction * Time.deltaTime;
            circlePos.x += axisInput.x * velocity * Time.deltaTime;
            circlePos.y += axisInput.y * velocity * Time.deltaTime;
            
            if (velocity <= 0)
            {
                velocity = 0;
            }
        }

        //Debug.Log("Velocity = " + velocity);
        
    }
}
