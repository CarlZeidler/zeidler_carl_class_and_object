using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : ProcessingLite.GP21
{
    private Vector2 playerCirclePos;
    private Vector2 axisInput;
    private float velocity = 6f;
    private float acceleration = 3f;
    private float circleDiam = 1f;
    private float friction = 3f;
    private float speedLimit = 8f;
    
    public playerController()
    {

    }

    public void createPlayer()
    {
        playerCirclePos = new Vector2(1, 1);
        Background(255);
        Fill(0);
        Stroke(255);
        Circle(playerCirclePos.x, playerCirclePos.y, circleDiam);
    }

    public void playerBoundaries()
    {
        if (playerCirclePos.x + circleDiam / 2 >= Width - 0.1 || (playerCirclePos.x - circleDiam / 2) <= 0.2)
        {
            axisInput.x = -axisInput.x;
        }

        if (playerCirclePos.y + circleDiam / 2 >= Height - 0.1 || playerCirclePos.y - circleDiam / 2 <= 0.2)
        {
            axisInput.y = -axisInput.y;
        }
    }

    public void playerInput()
    {
        Background(255);
        Fill(0);
        Stroke(255);
        Circle(playerCirclePos.x, playerCirclePos.y, circleDiam);

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float axisCheck = Mathf.Abs(x) + Mathf.Abs(y);
        
        if (axisCheck != 0) 
        {
            axisInput = new Vector2(x, y).normalized;

            velocity += acceleration * Time.deltaTime;

            playerCirclePos += axisInput * velocity * Time.deltaTime;

            //Limit speed
            if (velocity >= speedLimit)
            {
                velocity = speedLimit;
            }
        }

        if (axisCheck == 0)
        {
            velocity -= friction * Time.deltaTime;
            playerCirclePos.x += axisInput.x * velocity * Time.deltaTime;
            playerCirclePos.y += axisInput.y * velocity * Time.deltaTime;

            if (velocity <= 0)
            {
                velocity = 0;
            }
        }
    }
    public Vector2 playerPos()
    {
        return (playerCirclePos);
    }
    public float playerSize()
    {
        return (circleDiam);
    }
}
