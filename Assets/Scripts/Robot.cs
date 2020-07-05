using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Robot : MonoBehaviour
{
    private List<string> directions = new List<string> { "front", "left", "back", "right" };
    public Vector3 currentPosition;
    void Start()
    {

    }

    void Update()
    {
        currentPosition = this.transform.position;
        this.gameObject.name = "RB(" + currentPosition.x.ToString() + ", " + currentPosition.z.ToString() + ")";
    }
}
