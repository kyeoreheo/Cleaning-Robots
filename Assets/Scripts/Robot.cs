using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class Robot : MonoBehaviour
{
    public Vector3 currentPosition;
    public float moveOnEverySecond;

    private List<string> directions = new List<string> { "front", "left", "back", "right" };
    public bool shouldMove = true;
    private Vector3 destinationBlock;

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
        Timer();
        MoveRandom();
    }

    private void Timer()
    {
        currentTimer += Time.deltaTime;
        if (currentTimer >= moveOnEverySecond)
        {
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
        if (direction == "fornt")
        {
            this.transform.rotation = Quaternion.AngleAxis(180.0f, Vector3.up);

        }
        else if (direction == "left")
        {
            this.transform.rotation = Quaternion.AngleAxis(-90.0f, Vector3.up);
        }
        else if (direction == "back")
        {
            this.transform.rotation = Quaternion.AngleAxis(-180.0f, Vector3.up);
        }
        else if (direction == "right")
        {
            this.transform.rotation = Quaternion.AngleAxis(90.0f, Vector3.up);
        }

    }

    public void MoveRandom()
    {
        if (direction == "fornt")
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
        destinationBlock = new Vector3(currentPosition.x, 1.5f, currentPosition.z + 1);
        if (this.transform.position.z <= destinationBlock.z && shouldMove)
        {
            this.transform.position += Vector3.forward * Time.deltaTime * speed;
        }
        else
        {
            shouldMove = false;
            currentPosition = this.gameObject.transform.position;
        }
    }

    private void MoveLeft()
    {
        destinationBlock = new Vector3(currentPosition.x - 1, 1.5f, currentPosition.z);
        if (this.transform.position.x >= destinationBlock.x && shouldMove)
        {
            this.transform.position += Vector3.left * Time.deltaTime * speed;
        }
        else
        {
            shouldMove = false;
            currentPosition = this.gameObject.transform.position;
        }
    }

    private void MoveBack()
    {
        destinationBlock = new Vector3(currentPosition.x, 1.5f, currentPosition.z - 1);
        if (this.transform.position.z >= destinationBlock.z && shouldMove)
        {
            this.transform.position += Vector3.back * Time.deltaTime * speed;
        }
        else
        {
            shouldMove = false;
            currentPosition = this.gameObject.transform.position;
        }
    }

    private void MoveRight()
    {
        destinationBlock = new Vector3(currentPosition.x + 1, 1.5f, currentPosition.z);
        if (this.transform.position.x <= destinationBlock.x && shouldMove)
        {
            this.transform.position += Vector3.right * Time.deltaTime * speed;
        }
        else
        {
            shouldMove = false;
            currentPosition = this.gameObject.transform.position;
        }
    }

}
