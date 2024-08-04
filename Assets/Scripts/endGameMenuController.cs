using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGameMenuController : MonoBehaviour
{
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button replayButton = root.Q<Button>("replayButton");
        replayButton.clicked += () => this.OnReplayClicked();

        Button backButton = root.Q<Button>("backButton");
        backButton.clicked += () => this.OnBackClicked();
    }

    // When the back button is pressed, load the start menu scene.
    public void OnBackClicked()
    {
        SceneManager.LoadScene("startGameUI");
    }

    // When the replay button is pressed, load the game scene.
    public void OnReplayClicked()
    {
        SceneManager.LoadScene("Game");
    }
}
