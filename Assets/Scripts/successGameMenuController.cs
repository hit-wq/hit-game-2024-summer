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
        string result;
        string heartAmount = (GameData.health / 2).ToString() +
            (GameData.health % 2 == 1 ? ".5" : "");
        string shieldAmount = (GameData.shield / 2).ToString() +
           (GameData.shield % 2 == 1 ? ".5" : "");
        if (GameData.shield == 0) { 
         result = "Congratulations!\nLevel cleared with " +
            heartAmount + " hearts!";
        }
        else
        {
            result = "Congratulations!\nLevel cleared with " +
            heartAmount + " hearts and " + shieldAmount + " shields!";

        }
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
