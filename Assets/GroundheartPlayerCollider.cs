using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Provide the obstacles with a way of damaging the player.
 */
public class GroundheartPlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Obtain a reference to the Player's PlayerController
        PlayerController playerController =
          other.gameObject.GetComponent<PlayerController>();

        // Register heal with player
        playerController.Heal();

        // Make this object disappear
        GameObject.Destroy(gameObject);
    }
}
