using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class startGameMenuController : MonoBehaviour
{
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button startgamebutton = root.Q<Button>("startgamebutton");
        startgamebutton.clicked += () => this.OnStartClicked();

    }

    // When the start button is pressed, load the Game scene.
    public void OnStartClicked()
    {
        SceneManager.LoadScene("Game");
    }
}
