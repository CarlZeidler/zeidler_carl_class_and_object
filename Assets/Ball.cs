using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : ProcessingLite.GP21
{
    private Vector2 position;
    private Vector2 velocity;
    private float size;
    int rFill;
    int gFill;
    int bFill;
    int rStroke;
    int gStroke;
    int bStroke;
    bool respawning = false;

    Player players;
    
    public Ball(float x, float y, float size, int rFill, int gFill, int bFill, int rStroke, int gStroke, int bStroke)
    {
        velocity = new Vector2();
        velocity.x = Random.Range(-3, 3);
        velocity.y = Random.Range(-3, 3);
        this.size = size;
        position = new Vector2(Random.Range(Width*0.3f, Width*0.7f), Random.Range(Height*0.3f, Height*0.7f));
        this.rFill = rFill;
        this.gFill = gFill;
        this.bFill = bFill;
        this.rStroke = rStroke;
        this.gStroke = gStroke;
        this.bStroke = bStroke;

        players = new Player();
    }

    public void Draw()
    {
        Fill(rFill, gFill, bFill);
        Stroke(rStroke, gStroke, bStroke);
        Circle(position.x, position.y, size);
    }

    public void Dead()
    {
        position = new Vector2(Random.Range(Width * 0.3f, Width * 0.7f), Random.Range(Height * 0.3f, Height * 0.7f));
    }

    public void UpdatePos()
    {
        position += velocity * Time.deltaTime;
    }

    public void EdgeDetection()
    {
        if ((position.x + size / 2) >= Width || (position.x - size / 2) <= 0)
        {
            velocity.x = -velocity.x;
        }
        if ((position.y + size / 2) >= Height || (position.y - size / 2) <= 0)
        {
            velocity.y = -velocity.y;
        }
    }

    public bool collisioncheck(Vector2 x, float y)
    {
        //Vector2 playerCirclePos = players.PlayerPosition();
        Vector2 playerCirclePos = new Vector2(x.x, x.y);
        //float playercirclesize = players.PlayerSize();
        float playercirclesize = y;

        Debug.Log("player position = " + playerCirclePos);
        Debug.Log("circle position = " + position);

        if (CircleCollision(position.x, position.y, size, playerCirclePos.x, playerCirclePos.y, (playercirclesize / 2)) == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CircleCollision(float x1, float y1, float size1, float x2, float y2, float size2)
    {
        float maxDistance = size1 + size2;

        if (Mathf.Abs(x1 - x2) > maxDistance || Mathf.Abs(y1 - y2) > maxDistance)
        {
            return false;
        }
        else if (Vector2.Distance(new Vector2(x1, y1), new Vector2(x2, y2)) > maxDistance)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}


