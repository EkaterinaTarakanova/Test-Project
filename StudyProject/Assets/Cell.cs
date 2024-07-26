using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private bool isVisited = false;
    private bool[] status = new bool[4];

    public bool IsVisited { get => isVisited; set => isVisited = value; }
    public bool[] Status { get => status; set => status = value; }
}
