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
        for (int b = 0; b < board_.Count; b++)
        {
            board_[b].GetComponent<Block>().type = "None";

            for (int r = 0; r < robots_.Count; r++)
            {
                Vector3 robotPosition = robots_[r].GetComponent<Robot>().currentPosition;
                if (board_[b].transform.position.x == robotPosition.x && board_[b].transform.position.z == robotPosition.z)
                {
                    board_[b].GetComponent<Block>().type = "Robot";
                }
            }

            for (int g = 0; g < golds_.Count; g++)
            {
                Vector3 goldPosition = golds_[g].GetComponent<Gold>().currentPosition;
                if (board_[b].transform.position.x == goldPosition.x && board_[b].transform.position.z == goldPosition.z)
                {
                    board_[b].GetComponent<Block>().type = "Gold";
                }
            }
        }


        //for (int i = 0; i < robots_.Count; i++)
        //{
        //    Vector3 robotPosition = robots_[i].GetComponent<Robot>().currentPosition;
        //    for (int j = 0; j < board_.Count; j++)
        //    {
        //        if (board_[j].transform.position.x == robotPosition.x && board_[j].transform.position.z == robotPosition.z)
        //        {
        //            board_[j].GetComponent<Block>().type = "Robot";
        //        }
        //    }
        //}

        //for (int i = 0; i < golds_.Count; i++)
        //{
        //    Vector3 goldPosition = golds_[i].GetComponent<Gold>().currentPosition;
        //    for (int j = 0; j < board_.Count; j++)
        //    {
        //        if (board_[j].transform.position.x == goldPosition.x && board_[j].transform.position.z == goldPosition.z)
        //        {
        //            board_[j].GetComponent<Block>().type = "Gold";
        //        }
        //    }
        //}
    }
}
