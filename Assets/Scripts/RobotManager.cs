using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour
{
    public int robotNumber;
    public int boardSize;
    public Transform robot;

    private int robotCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Random.RandomRange(0, boardSize));
        for (int x = 0; x < boardSize; x++)
        {
            for (int z = 0; z < boardSize; z++)
            {
                if (robotCount < robotNumber)
                {
                    Transform copidRobot = Instantiate(robot, new Vector3(Random.RandomRange(0, boardSize), 1.5f, z), Quaternion.identity);
                    copidRobot.parent = this.gameObject.transform;
                    copidRobot.gameObject.name = "RB(" + x.ToString() + ", " + z.ToString() + ")";
                    robotCount++;

                }

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
