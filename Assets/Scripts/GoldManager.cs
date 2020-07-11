using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public MainSystem mainSystem;
    public int numberOfGolds;
    public int boardSize;
    public Transform gold;

    private int goldCount = 0;
    public List<Vector3> occupiedBlocks = new List<Vector3>();

    public void GenerateGolds()
    {
        for (int x = 0; x < boardSize; x++)
        {
            for (int z = 0; z < boardSize; z++)
            {
                if (goldCount < numberOfGolds)
                {
                    int randomX = Random.RandomRange(0, boardSize);
                    Vector3 targetBlock = new Vector3(randomX, 1.0f, z);
                    if (!occupiedBlocks.Contains(targetBlock))
                    {
                        occupiedBlocks.Add(targetBlock);
                        Transform copiedGold = Instantiate(gold, targetBlock, Quaternion.identity);
                        copiedGold.parent = this.gameObject.transform;
                        copiedGold.gameObject.name = "GD(" + randomX.ToString() + ", " + z.ToString() + ")";
                        mainSystem.golds_.Add(copiedGold);
                        goldCount++;
                    }
                }
            }
        }
    }
}
