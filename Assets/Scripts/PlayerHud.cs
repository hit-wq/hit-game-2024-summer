using UnityEngine;

/*
 * On screen HUD to display current health.
 */
public class PlayerHud : MonoBehaviour
{
    private PlayerController playerController;
    private Texture2D halfHeart;
    private Texture2D heart;
    private Texture2D halfshield;
    private Texture2D shield;
    /*
     * Load and store the heart images and cache the PlayerController
     * component for later.
     */
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        heart = Resources.Load<Texture2D>("heart");
        halfHeart = Resources.Load<Texture2D>("halfHeart");
        shield = Resources.Load<Texture2D>("shield");
        halfshield = Resources.Load<Texture2D>("halfshield");


    }

    /*
     * Using the current health from the PlayerController, display the
     * correct number of hearts and half hearts.
     */
    /*private void OnGUI()
    {
        if (playerController.GetHealth() == 6)
        {
            GUI.DrawTexture(new Rect(10, 10, 50, 50), heart);
            GUI.DrawTexture(new Rect(60, 10, 50, 50), heart);
            GUI.DrawTexture(new Rect(110, 10, 50, 50), heart);
        }
        else if (playerController.GetHealth() == 5)
        {
            GUI.DrawTexture(new Rect(10, 10, 50, 50), heart);
            GUI.DrawTexture(new Rect(60, 10, 50, 50), heart);
            GUI.DrawTexture(new Rect(110, 10, 50, 50), halfHeart);
        }
        else if (playerController.GetHealth() == 4)
        {
            GUI.DrawTexture(new Rect(10, 10, 50, 50), heart);
            GUI.DrawTexture(new Rect(60, 10, 50, 50), heart);
        }
        else if (playerController.GetHealth() == 3)
        {
            GUI.DrawTexture(new Rect(10, 10, 50, 50), heart);
            GUI.DrawTexture(new Rect(60, 10, 50, 50), halfHeart);
        }
        else if (playerController.GetHealth() == 2)
        {
            GUI.DrawTexture(new Rect(10, 10, 50, 50), heart);
        }
        else if (playerController.GetHealth() == 1)
        {
            GUI.DrawTexture(new Rect(10, 10, 50, 50), halfHeart);
        }
    }*/

    private void OnGUI()
    {
        int shield_start_position = 0;

        if (playerController.GetHealth() == 6)
        {
            GUI.DrawTexture(new Rect(10, 10, 50, 50), heart);
            GUI.DrawTexture(new Rect(60, 10, 50, 50), heart);
            GUI.DrawTexture(new Rect(110, 10, 50, 50), heart);
            shield_start_position = 160;
        }
        else if (playerController.GetHealth() == 5)
        {
            GUI.DrawTexture(new Rect(10, 10, 50, 50), heart);
            GUI.DrawTexture(new Rect(60, 10, 50, 50), heart);
            GUI.DrawTexture(new Rect(110, 10, 50, 50), halfHeart);
            shield_start_position = 160;
        }
        else if (playerController.GetHealth() == 4)
        {
            GUI.DrawTexture(new Rect(10, 10, 50, 50), heart);
            GUI.DrawTexture(new Rect(60, 10, 50, 50), heart);
            shield_start_position = 110;
        }
        else if (playerController.GetHealth() == 3)
        {
            GUI.DrawTexture(new Rect(10, 10, 50, 50), heart);
            GUI.DrawTexture(new Rect(60, 10, 50, 50), halfHeart);
            shield_start_position = 110;
        }
        else if (playerController.GetHealth() == 2)
        {
            GUI.DrawTexture(new Rect(10, 10, 50, 50), heart);
            shield_start_position = 60;
        }
        else if (playerController.GetHealth() == 1)
        {
            GUI.DrawTexture(new Rect(10, 10, 50, 50), halfHeart);
            shield_start_position = 60;
        }

        int theshield = playerController.GetShield();
        while (theshield > 1)
        {
            GUI.DrawTexture(new Rect(shield_start_position, 10, 50, 50), shield);
            shield_start_position = shield_start_position + 50;
            theshield = theshield - 2;
        }
        if (theshield == 1)
        {
            GUI.DrawTexture(new Rect(shield_start_position, 10, 50, 50), halfshield);
        }
    }
}
