using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ProcessingLite.GP21
{
    private float ballSize;
    private int numberOfBalls = 10;
    private float ballPosX;
    private float ballPosY;
    private int rFill;
    private int gFill;
    private int bFill;
    private int rStroke;
    private int gStroke;
    private int bStroke;
    public bool gameOver;
    public Vector2 playerPos;
    public float newPlayerSize;
    private float line1;
    private float line2;
    private float line3;
    private float line4;

    Ball[] balls;
    public playerController controller;

    void Start()
    {
        Application.targetFrameRate = 60;
        balls = new Ball[numberOfBalls];
        controller = new playerController();
        controller.createPlayer();

        line1 = Width * .33f;
        line2 = Height * .4f;
        line3 = Width * .67f;
        line4 = Height * .4f;

        for (int i = 0; i < balls.Length; i++)
        {
            ballPosX = Random.Range(3, 8);
            ballPosY = Random.Range(2, 6);
            ballSize = Random.Range(0.2f, 1f);
            rFill = Random.Range(50, 175);
            gFill = Random.Range(50, 175);
            bFill = Random.Range(50, 175); 
            rStroke = Random.Range(50, 175);
            gStroke = Random.Range(50, 175);
            bStroke = Random.Range(50, 175);
            balls[i] = new Ball(ballPosX, ballPosY, ballSize, rFill, gFill, bFill, rStroke, gStroke, bStroke);
        }
    }

    void Update()
    {
        controller.playerInput();
        controller.playerBoundaries();

        if (gameOver == false)
        {
            for (int i = 0; i < balls.Length; i++)
            {
                balls[i].Draw();
            }

            for (int i = 0; i < balls.Length; i++)
            {
                balls[i].UpdatePos();
                balls[i].EdgeDetection();
                if (balls[i].collisioncheck(controller.playerPos(), controller.playerSize()) == true)
                {
                    gameOver = true;
                }
            }
        }
        else
        {
            Background(255);
            Stroke(0);
            Fill(0);
            TextSize(100);
            Text("Ball obliterated", Width/2, Height/2);
            Stroke(0);
            Fill(255);
            Line(line1, line2, line3, line4);
            Stroke(0);
            Fill(0);
            TextSize(60);
            Text("Press R to Respawn", Width / 2, Height / 3);
            

            if (Input.GetKeyDown(KeyCode.R))
            {
                gameOver = false;
                Start();
            }

        }
    }
}
