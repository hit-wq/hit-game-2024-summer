using UnityEngine;

/*
 * Provide the obstacles with a way of damaging the player.
 */
public class angelheartplaycontroller : MonoBehaviour
{
    /*
     * A trigger callback to detect when the player's collider has
     * entered the obstacle's. Then simply obtain the PlayerController
     * reference can apply damage. Then remove the obstacle for feedback.
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Obtain a reference to the Player's PlayerController
        PlayerController playerController =
          other.gameObject.GetComponent<PlayerController>();

        // Register damage with player
        playerController.HealAll();
      
        // Make this object disappear
        GameObject.Destroy(gameObject);
    }
}
