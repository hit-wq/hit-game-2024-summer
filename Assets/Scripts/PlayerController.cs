using LevelSelection;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Behaviour to handle keyboard input and also store the player's
 * current health.
 */

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    private bool canJump;

    /*
     * Apply initial health and also store the Rigidbody2D reference for
     * future because GetComponent<T> is relatively expensive.
     */
    private void Start()
    {
       //红心护盾初始设置的逻辑改到levelinitializer.cs里了

        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    /*
     * Remove one health unit from player and if health becomes 0, change
     * scene to the end game scene.
     */
    public void Damage()
    {
        if (GameData.shield > 0)
        { GameData.shield = GameData.shield - 1; }
        else
        { GameData.health -= 1; }

        if (GameData.health < 1)
        {
            SceneManager.LoadScene("EndGameUI");
        }
    }
    public void Heal()
    {

        if (GameData.health == 6)
        {
            return;
        }
        GameData.health += 1;
    }

    public void HealAll()
    {
        GameData.health = 6;
    }
        public void AddShield()
    {

        GameData.shield += 1;
    }
    /*
     * Level success, change scene to success game scene
     */
    public void Success()
    {
        ClearData.UpdateClearEntry(GameData.levelInfo.levelId, new ClearData.ClearEntry(GameData.levelInfo.difficulty, GameData.health));
        SceneManager.LoadScene("SuccessGameUI");
    }

    /*
     * Accessor for health variable, used by he HUD to display health.
     */
    public int GetHealth()
    {
        return GameData.health;
    }
    public int GetShield()
    {
        return GameData.shield;
    }
    /*
     * Poll keyboard for when the up arrow is pressed. If the player can jump
     * (is on the ground) then add force to the cached Rigidbody2D component.
     * Finally unset the canJump flag so the player has to wait to land before
     * another jump can be triggered.
     */
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (canJump == true)
            {
                rigidbody2d.AddForce(new Vector2(0, 500));
                canJump = false;
            }
        }
    }

    /*
     * If the player has collided with the ground, set the canJump flag so that
     * the player can trigger another jump.
     */
    private void OnCollisionEnter2D(Collision2D other)
    {
        canJump = true;
    }
}
