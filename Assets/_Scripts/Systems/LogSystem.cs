using UnityEngine;

public enum LogType
{
    None,
    Log,
    Warning,
    Error,
    Todo
}


public class LogSystem : Singleton<LogSystem>
{
    [SerializeField] bool _logEnabled = true;

    public void Log(string message, LogType type = LogType.Log, string _logTag = "N/A")
    {
        if (!_logEnabled) return;
        switch (type)
        {
            case LogType.Log:
                Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(Color.black)}>[{_logTag}]</color> {message}");
                break;
            case LogType.Warning:
                Debug.LogWarning($"<color=#{ColorUtility.ToHtmlStringRGB(Color.orange)}>[{_logTag}]</color> {message}");
                break;
            case LogType.Error:
                Debug.LogError($"<color=#{ColorUtility.ToHtmlStringRGB(Color.red)}>[{_logTag}]</color> {message}");
                break;
            case LogType.Todo:
                Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(Color.green)}>[{_logTag}] TODO:</color> {message}");
                break;
            default:
                break;
        }
    }
}
