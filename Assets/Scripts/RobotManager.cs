using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour
{
    public MainSystem mainSystem;
    public int robotNumber;
    public int boardSize;
    public Transform robot;

    private int robotCount = 0;
    private List<Vector3> occupiedBlocks = new List<Vector3>();

    void Start()
    {
        for (int x = 0; x < boardSize; x++)
        {
            for (int z = 0; z < boardSize; z++)
            {
                if (robotCount < robotNumber)
                {
                    int randomX = Random.RandomRange(0, boardSize);
                    Vector3 targetBlock = new Vector3(randomX, 1.5f, z);
                    if (!occupiedBlocks.Contains(targetBlock))
                    {
                        occupiedBlocks.Add(targetBlock);
                        Transform copiedRobot = Instantiate(robot, targetBlock, Quaternion.identity);
                        copiedRobot.parent = this.gameObject.transform;
                        copiedRobot.gameObject.name = "RB(" + randomX.ToString() + ", " + z.ToString() + ")";
                        mainSystem.robots_.Add(copiedRobot);
                        robotCount++;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
