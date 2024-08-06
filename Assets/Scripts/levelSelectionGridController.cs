using LevelSelection;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class levelSelectionGridController : MonoBehaviour
{
    public VisualTreeAsset buttonTemplate; // The UXML template for the button

    public VisualTreeAsset levelRowTemplate;

    public TextAsset levelSelectionJson;

    private LevelSelectionData levelSelectionData;

    private ScrollView scrollViewContent; // The content panel of the scroll view

    void Awake()
    {
        levelSelectionData = ParseLevelSelection(levelSelectionJson);
    }

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        scrollViewContent = root.Q<ScrollView>("BaseLevelContainer");
        // Assuming the ScrollView and its content are already set up in the UXML file
        // and assigned to the scrollViewContent variable in the inspector.
        if (scrollViewContent == null)
        {
            Debug.LogError("The ScrollView content reference is not set.");
            return;
        }
        foreach (var row in levelSelectionData.rows)
        {
            AddRow(scrollViewContent, row);
        }
        
    }

    public LevelSelection.LevelSelectionData ParseLevelSelection(TextAsset jsonData)
    {
        LevelSelectionData levelSelectionData = JsonUtility.FromJson<LevelSelectionData>(jsonData.text);
        return levelSelectionData;
    }

    void AddRow(ScrollView scrollView, RowData row)
    {
        VisualElement rowFromTemplate = levelRowTemplate.Instantiate();
        VisualElement rowContainer = rowFromTemplate.Q<VisualElement>("RowContainer");
        Label titleUI = rowFromTemplate.Q<Label>("Title");
        titleUI.text = row.title;

        foreach (var level in row.levels)
        {
            AddButton(rowContainer, level);
        }

        scrollView.Add(rowContainer);
    }

    void AddButton(VisualElement parent, LevelData level)
    {
        // Instantiate the button from the UXML template
        VisualElement buttonFromTemplate = buttonTemplate.Instantiate();
        Button button = buttonFromTemplate.Q<Button>("button"); // Assuming the Button has a class name "dynamic-button"

        // Set the button text to the index
        button.text = level.label;

        // Add listener for the button click
        button.RegisterCallback<ClickEvent>(ev => ButtonClicked(level));

        // Add the button to the ScrollView content
        parent.Add(button);
    }

    void ButtonClicked(LevelData level)
    {
        // TODO: Create a popup where user can select difficulty.
        string jsonName = level.jsonfilename + "_" + "easy";
        GameData.levelJsonPath = "Levels/" + jsonName;
        Debug.Log($"Button {level.label} clicked, should jump to {jsonName}, filepath: {GameData.levelJsonPath}");
        SceneManager.LoadScene("Game");
    }
}
