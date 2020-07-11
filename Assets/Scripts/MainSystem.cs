using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSystem : MonoBehaviour
{
    public RobotManager robotManager_;
    public BoardManager boardManager_;
    public GoldManager goldManager_;

    public List<Transform> board_ = new List<Transform>();
    public List<Transform> robots_ = new List<Transform>();
    public List<Transform> golds_ = new List<Transform>();

    void Start()
    {
        robotManager_.GenerateRobots();
        boardManager_.GenerateBoard();
        Debug.Log(robotManager_.occupiedBlocks.Count);
        goldManager_.occupiedBlocks = robotManager_.occupiedBlocks;
        goldManager_.GenerateGolds();
    }

    void Update()
    {
        for (int i = 0; i < robots_.Count; i++)
        {
            Vector3 position = robots_[i].GetComponent<Robot>().currentPosition;
            for (int j = 0; j < board_.Count; j++)
            {
                if (board_[j].transform.position.x == position.x && board_[j].transform.position.z == position.z)
                {
                    board_[j].GetComponent<Block>().type = "Robot";
                }
                else
                {
                    board_[j].GetComponent<Block>().type = "None";
                }
            }
        }
    }
}
