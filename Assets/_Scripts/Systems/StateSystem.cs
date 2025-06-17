using UnityEngine;
using System;

public class StateSystem : PersistentSingleton<StateSystem>
{
    public static event Action<GameStates> OnBeforeStateChanged;
    public static event Action<GameStates> OnAfterStateChanged;
    public GameStates State { get; private set; }

    public enum GameStates
    {
        Initialize,
    }

    private void Start() => ChangeGameState(GameStates.Initialize);

    private void ChangeGameState(GameStates newState)
    {
        OnBeforeStateChanged?.Invoke(newState);

        State = newState;
        switch (State)
        {
            case GameStates.Initialize:
                State_InitializeHandler();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnAfterStateChanged?.Invoke(newState);
        LogSystem.Instance.Log($"State changed to: {newState}", LogType.Info, "StateManager");
    }

    private void State_InitializeHandler()
    {
        LogSystem.Instance.Log("Game is initializing...", LogType.Info, "StateManager");

    }
}
