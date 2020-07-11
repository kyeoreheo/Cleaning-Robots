using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSystem : MonoBehaviour
{
    public List<Transform> board_ = new List<Transform>();
    public List<Transform> robots_ = new List<Transform>();

    void Start()
    {
        
    }

    void Update()
    {
        for (int i = 0; i < robots_.Count; i++)
        {
            Vector3 position = robots_[i].GetComponent<Robot>().currentPosition;
            Debug.Log(position);

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
