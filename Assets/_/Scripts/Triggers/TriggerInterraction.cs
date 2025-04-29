using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerInterraction : MonoBehaviour
{
    public event Action Interracted;
    [field: SerializeField] public UnityEvent EventInterracted { get; private set; }
    [field: SerializeField] public TriggerCollision TriggerCollision { get; private set; }
    public bool CanInterract { get; private set; }
    private event Action<TriggerInterraction> _callbackEnterInterract;
    private event Action<TriggerInterraction> _callbackExitInterract;

    void OnEnable()
    {
        if (!TriggerCollision)
            Debug.LogError($"[ {nameof(TriggerInterraction)} ] {name} need a {nameof(TriggerCollision)} Component");
        TriggerCollision.BodyEntered += OnBodyEntered;
        TriggerCollision.BodyExited += OnBodyExited;
    }

    public void Interract()
    {
        if (CanInterract)
        {
            Interracted?.Invoke();
            EventInterracted?.Invoke();
        }
    }

    private void OnBodyEntered(GameObject _)
    {
        CanInterract = true;
        _callbackEnterInterract(this);
    }

    private void OnBodyExited(GameObject _)
    {
        CanInterract = false;
        _callbackExitInterract(this);

    }

    public void ConnectTriggerInterract(Action<TriggerInterraction> enterInterract, Action<TriggerInterraction> exiteInterract)
    {
        _callbackEnterInterract = enterInterract;
        _callbackExitInterract = exiteInterract;
    }
}
