using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Provide the obstacles with a way of damaging the player.
 */
public class GroundshieldPlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        // Obtain a reference to the Player's PlayerController
        PlayerController playerController =
          other.gameObject.GetComponent<PlayerController>();
        if (audioSource != null)
        {
            audioSource.Play();

        }
        // Register heal with player
        playerController.AddShield();

        // Make this object disappear
        
        GetComponent<Collider2D>().enabled = false;


        GetComponent<SpriteRenderer>().enabled = false;
    }
}
