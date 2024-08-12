using UnityEngine;

/*
 * Provide the obstacles with a way of damaging the player.
 */ 
public class BarrelPlayerCollider : MonoBehaviour
{
    /*
     * A trigger callback to detect when the player's collider has
     * entered the obstacle's. Then simply obtain the PlayerController
     * reference can apply damage. Then remove the obstacle for feedback.
     */

    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        // Obtain a reference to the Player's PlayerController
        PlayerController playerController =
          other.gameObject.GetComponent<PlayerController>();

        // Register damage with player
        if (audioSource != null)
        {
            audioSource.Play();
   
        }
       

        playerController.Damage();
     
        GetComponent<Collider2D>().enabled = false;

      
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
