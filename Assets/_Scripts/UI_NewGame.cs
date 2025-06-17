using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class UI_NewGame : MonoBehaviour
{
    const string _logTag = "UI_NewGame";

    [Header("Properties")]
    [SerializeField] CardType cardType;
    public enum CardType
    {
        NewGame,
        LoadSave,
    }
    [SerializeField] string gameName;
    [SerializeField] int gameID;
    [SerializeField] string gameData;
    [SerializeField] Texture2D gameIcon;


    [Header("Dependencies")]
    [SerializeField] TMP_InputField _gameName;
    [SerializeField] TextMeshProUGUI _gameData;
    [SerializeField] SpriteRenderer _gameIcon;
    [SerializeField] Button _deleteButton;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        // Initialize Properties and UI Elements based on CardType
        if (cardType == CardType.NewGame)
        {
            // Properties
            gameName = string.Empty;
            gameID = UnityEngine.Random.Range(1000, 9999);
            gameData = string.Empty;
            gameIcon = null;

            // UI Elements
            _gameName.ActivateInputField();
            _gameData.text = string.Empty;
            _gameIcon.sprite = null;
        }
        else if (cardType == CardType.LoadSave)
        {
            LogSystem.Instance.Log("Loading Save Card: " + gameID, LogType.Todo, _logTag);
        }
    }

    public void OnButtonClick()
    {
        if (cardType == CardType.NewGame)
        {
            // Handle New Save Logic
            gameName = _gameName.text;
            cardType = CardType.LoadSave;
            SaveLoadSystem.Instance.NewGame(gameName);
            LogSystem.Instance.Log($"New Save Created: {gameName} (ID: {gameID})", LogType.Info, _logTag);
        }
        else if (cardType == CardType.LoadSave)
        {
            // Handle Load Save Logic
            LogSystem.Instance.Log($"Loading Save: {gameName} (ID: {gameID})", LogType.Info, _logTag);
        }
    }
}
