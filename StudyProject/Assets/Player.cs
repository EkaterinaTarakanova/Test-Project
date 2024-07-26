using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<Player, Color> ColorChanged;
    private Renderer playerRenderer;
    private List<Color> colorSet = new List<Color>() { Color.red, Color.green, Color.blue };
    private int currentIndex = 0;

    private void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        InvokeRepeating("ChangeColor", 0f, 2.5f);
    }

    private void ChangeColor()
    {
        var newColor = colorSet[currentIndex];
        currentIndex = (currentIndex + 1) % colorSet.Count;
        playerRenderer.material.color = newColor;
        string colorName = GetColorName(newColor);
        ColorChanged?.Invoke(this, newColor);
    }

    public static string GetColorName(Color color)
    {
        if (color.Equals(Color.red))
        {
            return "Красный";
        }
        else if (color.Equals(Color.green))
        {
            return "Зелёный";
        }
        else
        {
            return "Синий";
        }
    }
}
