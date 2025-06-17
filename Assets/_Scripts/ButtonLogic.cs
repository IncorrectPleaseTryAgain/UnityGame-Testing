using UnityEngine;
using System;

[Tooltip("Defines the actions that can be performed by buttons in the game.")]
public enum Action
{
    None,
    LoadScene,
    LoadChapter,
    LoadLevel,
    DisplayOverlay,
    RemoveOverlay,
    CreateNewSave,
    Unpause,
    QuitGame
}

[Tooltip("Defines the scenes available in the game.")]
public enum Scene
{
    None,
    Scene_TitleScreen,
    Scene_MainMenu,
    Scene_ChapterSelect,
    Scene_LevelSelect,
    Scene_Game,
    Scene_Credits,
    Scene_Settings,
    PreviousScene,
}

[Tooltip("Defines the chapter to play")]
public enum Chapter
{
    None,
    Chapter_1,
    Chapter_2,
    Chapter_3,
    Chapter_4,
    Chapter_5
}

[Tooltip("Defines the level to play")]
public enum Level
{
    None,
    Level_1,
    Level_2,
    Level_3,
    Level_4,
    Level_5
}

[Tooltip("Defines the overlay to appear")]
public enum Overlay
{
    None,
    Overlay_NewSave,
    Overlay_Quit,
    Overlay_Death,
    Overlay_Pause
}

public class ButtonLogic : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] Action action;
    [SerializeField] Scene scene;
    [SerializeField] Overlay overlay;
    [SerializeField] Chapter chapter;
    [SerializeField] Level level;

    string _logTag = "ButtonLogic";

    public void ExecuteAction()
    {
        LogSystem.Instance.Log($"Executing action: {action}", LogType.Info, _logTag);
        switch (action)
        {
            case Action.LoadScene:
                LoadScene();
                break;
            case Action.LoadChapter:
                LoadChapter();
                break;
            case Action.LoadLevel:
                LoadLevel();
                break;
            case Action.QuitGame:
                QuitGame();
                break;
            case Action.DisplayOverlay:
                DisplayOverlay();
                break;
            case Action.RemoveOverlay:
                RemoveOverlay();
                break;
            case Action.CreateNewSave:
                CreateNewSave();
                break;
            case Action.Unpause:
                Unpause();
                break;
            default:
                LogSystem.Instance.Log("No action defined for this button.", LogType.Warning, _logTag);
                break;
        }
    }

    private void RemoveOverlay()
    {
        if (overlay == Overlay.None)
        {
            LogSystem.Instance.Log("No overlay defined to remove.", LogType.Warning, _logTag);
            return;
        }
        string overlayName = Enum.GetName(typeof(Overlay), overlay);
        LogSystem.Instance.Log($"Removing overlay: {overlayName}", LogType.Todo, _logTag);
    }

    private void Unpause()
    {
        LogSystem.Instance.Log("Unpause action executed. This is a placeholder for future functionality. Temporarily redirects to main menu", LogType.Todo, _logTag);
        string mainMenu = Enum.GetName(typeof(Scene), Scene.Scene_MainMenu);
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenu);
    }

    private void CreateNewSave()
    {
        LogSystem.Instance.Log("Create new save action executed. This is a placeholder for future functionality. Temporarily redirects to main menu", LogType.Todo, _logTag);
        string mainMenu = Enum.GetName(typeof(Scene), Scene.Scene_MainMenu);
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenu);
    }

    private void DisplayOverlay()
    {
        if(overlay == Overlay.None)
        {
            LogSystem.Instance.Log("No overlay defined to display.", LogType.Warning, _logTag);
            return;
        }
        string overlayName = Enum.GetName(typeof(Overlay), overlay);
        LogSystem.Instance.Log($"Displaying overlay: {overlayName}", LogType.Todo, _logTag);
    }

    private void LoadLevel()
    {
        if (level == Level.None)
        {
            LogSystem.Instance.Log("No level defined to load.", LogType.Warning, _logTag);
            return;
        }
        LoadScene();
    }

    private void LoadChapter()
    {
        if(chapter == Chapter.None)
        {
            LogSystem.Instance.Log("No chapter defined to load.", LogType.Warning, _logTag);
            return;
        }
        LoadScene();
    }

    private void LoadScene()
    {
        if (scene == Scene.None)
        {
            LogSystem.Instance.Log("No scene defined to load.", LogType.Warning, _logTag);
            return;
        }
        if(scene == Scene.PreviousScene)
        {
            LogSystem.Instance.Log("Cannot load previous scene directly. Temporarily redirects to main menu", LogType.Todo, _logTag);
            string mainMenu = Enum.GetName(typeof(Scene), Scene.Scene_MainMenu);
            UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenu);
        }

        string sceneName = Enum.GetName(typeof(Scene), scene);
        LogSystem.Instance.Log($"Loading scene: {sceneName}");
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    private void QuitGame()
    {
        LogSystem.Instance.Log("Quitting game...");
        Application.Quit();

        // If running in the editor, stop playing
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
