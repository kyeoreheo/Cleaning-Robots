using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public MainSystem mainSystem;
    public int boardSize;
    public Transform block;
    public Material whiteMaterial;
    public Material blackMaterial;

    private bool isWhite = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < boardSize; x++)
        {
            isWhite = !isWhite;
            for (int z = 0; z < boardSize; z++)
            {
                Material currentMaterial;
                if (isWhite)
                {
                    currentMaterial = whiteMaterial;
                }
                else
                {
                    currentMaterial = blackMaterial;
                }
                Transform copiedBlock = Instantiate(block, new Vector3(x, 0, z), Quaternion.identity);
                copiedBlock.parent = this.gameObject.transform;
                copiedBlock.gameObject.GetComponent<MeshRenderer>().material = currentMaterial;
                isWhite = !isWhite;
                copiedBlock.gameObject.name = "(" + x.ToString() + ", " + z.ToString() + ")";
                mainSystem.board_.Add(copiedBlock);
            }

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
