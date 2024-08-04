using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class successGameMenuController : MonoBehaviour
{
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Label title = root.Q<Label>("Title");
        title.text = titleText();

        Button replayButton = root.Q<Button>("replayButton");
        replayButton.clicked += () => this.OnReplayClicked();

        Button backButton = root.Q<Button>("backButton");
        backButton.clicked += () => this.OnBackClicked();
    }

    // Generate title text
    private string titleText()
    {
        string heartAmount = (gameData.health / 2).ToString() +
            (gameData.health % 2 == 1 ? ".5" : "");
        string result = "Congratulations!\nLevel cleared with " +
            heartAmount + " hearts!";
        return result;
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
