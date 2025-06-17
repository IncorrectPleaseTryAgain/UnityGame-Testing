using UnityEngine;
using UnityEngine.Events;

public abstract class AbstractEventChannelListener<TEventChannel, TEventType>
    : MonoBehaviour where TEventChannel : GenericEventChannel<TEventType>
{
    [Header("Listen to Event Channels")]
    [SerializeField] protected TEventChannel EventChannel;
    [Tooltip("Responds to receiving signal from Event Channel")]
    [SerializeField] protected UnityEvent<TEventType> response;

    protected virtual void OnEnable()
    {
        if (EventChannel != null)
        {
            EventChannel.OnEventRaised.AddListener(OnEventRaised);
        }
    }

    protected virtual void OnDisable()
    {
        if (EventChannel != null)
        {
            EventChannel.OnEventRaised.RemoveListener(OnEventRaised);
        }
    }

    public void OnEventRaised(TEventType evt)
    {
        response?.Invoke(evt);
    }
}
