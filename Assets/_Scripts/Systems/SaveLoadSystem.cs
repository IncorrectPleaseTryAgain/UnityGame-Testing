using System;
using UnityEngine;

[Serializable] public class GameData
{
    public string gameName;
    public int gameID;
    public int playerScore;
}

public class SaveLoadSystem : PersistentSingleton<SaveLoadSystem>
{
    [SerializeField] public GameData gameData;

    IDataService dataService;

    protected override void Awake()
    {
        base.Awake();
        dataService = new FileDataService(new JsonSerializer());
    }

    public void NewGame(string name, int id)
    {
        gameData = new GameData
        {
            gameID = id,
            gameName = name,
            playerScore = 0
        };

        LogSystem.Instance.Log("New game started...");
    }

    public void SaveGame()
    {
        dataService.Save(gameData, true);
    }

    public void LoadGame(string saveName)
    {
        try
        {
            gameData = dataService.Load(saveName);

            if(String.IsNullOrEmpty(gameData.gameName))
            {
                gameData.gameName = "New Game";
            }

            LogSystem.Instance.Log($"Game loaded: {gameData.gameName}");
        }
        catch (Exception ex)
        {
            LogSystem.Instance.Log($"Failed to load game: {ex.Message}", LogType.Error);
        }
    }

    public void DeleteGame(string saveName)
    {
        try
        {
            dataService.Delete(saveName);
            LogSystem.Instance.Log($"Game deleted: {saveName}");
        }
        catch (Exception ex)
        {
            LogSystem.Instance.Log($"Failed to delete game: {ex.Message}", LogType.Error);
        }
    }
}
