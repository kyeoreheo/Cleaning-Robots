using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class Robot : MonoBehaviour
{
    public int boardSize;
    public Vector3 currentPosition;
    public float moveOnEverySecond;

    private List<string> directions = new List<string> { "front", "left", "back", "right" };
    public bool shouldMove = true;
    public Vector3 destinationBlock;

    public float currentTimer = 0;
    public float speed = 2;
    public string direction;
    void Start()
    {
        currentPosition = this.gameObject.transform.position;
        GenerateRandomDirection();
        RotateRobot();
    }

    void Update()
    {
        this.gameObject.name = "RB(" + this.transform.position.x.ToString() + ", " + this.transform.position.z.ToString() + ")";
        MoveRandom();
        Timer();
    }

    private void Timer()
    {
        currentTimer += Time.deltaTime;
        if (currentTimer >= moveOnEverySecond)
        {
            this.gameObject.transform.position = destinationBlock;

            currentTimer = 0;
            shouldMove = true;
            GenerateRandomDirection();
            RotateRobot();
        }
    }

    private void GenerateRandomDirection()
    {
        int randomIndex = Random.RandomRange(0, 4);
        direction = directions[randomIndex];
    }

    private void RotateRobot()
    {
        if (direction == "front")
        {
            this.transform.rotation = Quaternion.AngleAxis(0.0f, Vector3.up);
            destinationBlock = new Vector3(currentPosition.x, 1.5f, currentPosition.z + 1);
            if (destinationBlock.z > boardSize - 1)
                destinationBlock = new Vector3(destinationBlock.x, 1.5f, boardSize - 1);
        }
        else if (direction == "left")
        {
            this.transform.rotation = Quaternion.AngleAxis(-90.0f, Vector3.up);
            destinationBlock = new Vector3(currentPosition.x - 1, 1.5f, currentPosition.z);
            if (destinationBlock.x < 0)
                destinationBlock = new Vector3(0, 1.5f, destinationBlock.z);
        }
        else if (direction == "back")
        {
            this.transform.rotation = Quaternion.AngleAxis(-180.0f, Vector3.up);
            destinationBlock = new Vector3(currentPosition.x, 1.5f, currentPosition.z - 1);
            if (destinationBlock.z < 0)
                destinationBlock = new Vector3(destinationBlock.x, 1.5f, 0);
        }
        else if (direction == "right")
        {
            this.transform.rotation = Quaternion.AngleAxis(90.0f, Vector3.up);
            destinationBlock = new Vector3(currentPosition.x + 1, 1.5f, currentPosition.z);
            if (destinationBlock.x > boardSize - 1)
                destinationBlock = new Vector3(boardSize - 1, 1.5f, destinationBlock.z);
        }
    }

    public void MoveRandom()
    {
        if (direction == "front")
        {
            MoveForward();
        }
        else if (direction == "left")
        {
            MoveLeft();
        }
        else if (direction == "back")
        {
            MoveBack();
        }
        else if (direction == "right")
        {
            MoveRight();
        }
    }

    private void MoveForward()
    {
        if (destinationBlock.z < boardSize && shouldMove)
        {
            if (this.transform.position.z < destinationBlock.z)
            {
                this.transform.position += Vector3.forward * Time.deltaTime * speed;
            }
            else
            {
                shouldMove = false;
                this.gameObject.transform.position = destinationBlock;
                currentPosition = this.gameObject.transform.position;
            }
        }
    }

    private void MoveLeft()
    {
        if (destinationBlock.x >= 0 && shouldMove)
        {
            if (this.transform.position.x > destinationBlock.x)
            {
                this.transform.position += Vector3.left * Time.deltaTime * speed;
            }
            else
            {
                shouldMove = false;
                this.gameObject.transform.position = destinationBlock;
                currentPosition = this.gameObject.transform.position;
            }
        }
    }

    private void MoveBack()
    {
        if (destinationBlock.z >= 0 && shouldMove)
        {
            if (this.transform.position.z > destinationBlock.z)
            {
                this.transform.position += Vector3.back * Time.deltaTime * speed;
            }
            else
            {
                shouldMove = false;
                this.gameObject.transform.position = destinationBlock;
                currentPosition = this.gameObject.transform.position;
            }
        }

    }

    private void MoveRight()
    {
        if (destinationBlock.x < boardSize && shouldMove)
        {
            if (this.transform.position.x < destinationBlock.x)
            {
                this.transform.position += Vector3.right * Time.deltaTime * speed;
            }
            else
            {
                shouldMove = false;
                this.gameObject.transform.position = destinationBlock;
                currentPosition = this.gameObject.transform.position;
            }
        }
    }
}
