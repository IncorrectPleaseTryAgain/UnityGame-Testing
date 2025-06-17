using UnityEngine;
using UnityEngine.Events;

public abstract class GenericEventChannel<T> : ScriptableObject
{
    [Tooltip("The action to perform when the event is raised.")]
    public UnityEvent<T> OnEventRaised;

    public void RaisedEvent(T eventData)
    {
        OnEventRaised?.Invoke(eventData);
    }
}
