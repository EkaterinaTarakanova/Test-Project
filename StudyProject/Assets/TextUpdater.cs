using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour
{
    private Text colorText;
    [SerializeField] private Player player;

    private void Start()
    {
        colorText = GetComponent<Text>(); 
        player.ColorChanged += UpdateColorText;
    }

    private void UpdateColorText(Player player, Color newColor)
    {
        colorText.color = newColor;
    }
}
