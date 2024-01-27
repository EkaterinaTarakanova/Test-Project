using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public static int killCounter;
    private Text killText;
 
    void Start()
    {
        killText = GetComponent<Text>();
        killCounter = 0;
    }

    void Update()
    {
        killText.text = "Убито: " + killCounter.ToString();
    }
}
