using LevelSelection;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class levelSelectionGridController : MonoBehaviour
{
    public VisualTreeAsset levelButtonTemplate; // The UXML template for the button
    public VisualTreeAsset levelRowTemplate;
    public VisualTreeAsset popupButtonTemplate;
    public VisualTreeAsset popupTemplate;
    public TextAsset levelSelectionJson;
    private LevelSelectionData levelSelectionData;
    private ScrollView scrollViewContent; // The content panel of the scroll view
    private VisualElement root;

    void Awake()
    {
        levelSelectionData = LevelSelectionData.Parse(levelSelectionJson);
    }

    void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
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

    void AddRow(ScrollView scrollView, RowData row)
    {
        VisualElement rowFromTemplate = levelRowTemplate.Instantiate();
        VisualElement rowContainer = rowFromTemplate.Q<VisualElement>("RowContainer");
        Label titleUI = rowFromTemplate.Q<Label>("Title");
        titleUI.text = row.title;

        foreach (var level in row.levels)
        {
            AddLevelButton(rowContainer, level);
        }

        scrollView.Add(rowContainer);
    }

    void AddLevelButton(VisualElement parent, LevelSelection.LevelData level)
    {
        // Instantiate the button from the UXML template
        VisualElement buttonFromTemplate = levelButtonTemplate.Instantiate();
        Button button = buttonFromTemplate.Q<Button>("button");

        // Set the button text to the index
        button.text = level.label;

        // Add listener for the button click
        button.RegisterCallback<ClickEvent>(ev => LevelButtonClicked(level));

        // Add the button to the ScrollView content
        parent.Add(button);
    }

    void LevelButtonClicked(LevelData level)
    {
        PopupInstantiate(level);
    }

    void PopupInstantiate(LevelData level) {
        // TODO: Create a popup where user can select difficulty.
        VisualElement popupFromTemplate = popupTemplate.Instantiate().Q<VisualElement>("Popup");
        popupFromTemplate.Q<Label>("LevelName").text = level.label;
        popupFromTemplate.Q<Label>("LevelDescription").text = level.getClearInfo() + level.description;
        popupFromTemplate.Q<Button>("Exit").RegisterCallback<ClickEvent>(ev => {
            root.Remove(popupFromTemplate);
        });

        VisualElement buttonRow = popupFromTemplate.Q<VisualElement>("ButtonRow");
        foreach (string difficulty in level.difficulties)
        {
            string jsonName = level.jsonfilename + "_" + difficulty;
            AddPopupButton(buttonRow, difficulty, jsonName);
        }
        root.Add(popupFromTemplate);
    }

    void AddPopupButton(VisualElement parent, string difficulty, string jsonName)
    {
        // Instantiate the button from the UXML template
        VisualElement buttonFromTemplate = levelButtonTemplate.Instantiate();
        Button button = buttonFromTemplate.Q<Button>("button");

        // Set the button text to the index
        button.text = difficulty;

        // Add listener for the button click
        button.RegisterCallback<ClickEvent>(ev => PopupButtonClicked(jsonName));

        // Add the button to the ScrollView content
        parent.Add(button);
    }

    void PopupButtonClicked(string jsonName)
    {
        GameData.levelJsonPath = "Levels/" + jsonName;
        Debug.Log($"Jump to filepath: {GameData.levelJsonPath}");
        SceneManager.LoadScene("Game");
    }
}
