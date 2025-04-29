using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerCollision : MonoBehaviour
{
    public event Action<GameObject> BodyEntered;
    public event Action<GameObject> BodyExited;
    [field: SerializeField] public UnityEvent<GameObject> EventBodyEntered { get; private set; }
    [field: SerializeField] public UnityEvent<GameObject> EventBodyExited { get; private set; }
    [field: SerializeField] public Collider Collider { get; private set; }
    private event Action<TriggerCollision, Collider> _callbackTriggerEnter;
    private event Action<TriggerCollision, Collider> _callbackTriggerExit;

    void OnEnable()
    {
        if (!Collider)
            Debug.LogError($"[ {nameof(TriggerCollision)} ] {name} need a Collider Component");
        else if (!Collider.isTrigger)
            Debug.LogError($"[ {nameof(TriggerCollision)} ] {name} need a Collider Component with {nameof(Collider.isTrigger)} enabled");
    }

    private void OnTriggerEnter(Collider other)
    {
        _callbackTriggerEnter(this, other);
    }

    public void InvokeEventEntered(Collider other)
    {
        BodyEntered?.Invoke(other.gameObject);
        EventBodyEntered?.Invoke(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        _callbackTriggerExit(this, other);
    }

    public void InvokeEventExited(Collider other)
    {
        BodyExited?.Invoke(other.gameObject);
        EventBodyExited?.Invoke(other.gameObject);
    }

    public void ConnectTriggerCollisions(Action<TriggerCollision, Collider> enter, Action<TriggerCollision, Collider> exit)
    {
        _callbackTriggerEnter = enter;
        _callbackTriggerExit = exit;
    }
}
