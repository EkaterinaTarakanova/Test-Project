using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private AudioSource audioSource;
    private Player player;
  
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();  
        player = GetComponent<Player>();
        player.ColorChanged += PlaySound;
    }

    private void PlaySound(Player player, Color newColor) 
    {
        audioSource.Play();   
    }
}
