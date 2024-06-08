using CCC.UI;
using CCC.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartMenu : MonoBehaviour
{
    private UIDocument _uiDoc;

    [SerializeField] private IntReference _difficultyIndicatorValue;

    private void Start()
    {
        _uiDoc = GetComponent<UIDocument>();
        RegisterButtons();
    }

    private void RegisterButtons()
    {
        var root = _uiDoc.rootVisualElement;
        var playButton = root.Q<Button>("playButton");
        var quitButton = root.Q<Button>("quitButton");
        var _difficultyIndicator = root.Q<DifficultySelectorUIE>();
        _difficultyIndicator.SetScriptObjVarReference(_difficultyIndicatorValue);


        playButton.clicked += OnPressPlay;
        quitButton.clicked += OnPressQuit;
    }

    private void OnPressPlay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void OnPressQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}