using System.Collections.Generic;
using UnityEngine;

public class TriggersManager : BGSManager
{
    public TriggerCollision[] TriggersCollision { get; private set; }
    public HashSet<Collider> CollidersRegistered { get; private set; } = new();

    public override void Initialize(BGSGameManager gameManager)
    {
        base.Initialize(gameManager);

        TriggersCollision = FindObjectsByType<TriggerCollision>(FindObjectsSortMode.None);

        foreach (var trigger in TriggersCollision)
        {
            trigger.ConnectTriggerCollisions(OnTriggerCollisionEnter, OnTriggerCollisionExited);
        }
    }

    protected void OnTriggerCollisionEnter(TriggerCollision trigger, Collider other)
    {
        if (!IsRegistered(other)) return;
        trigger.InvokeEventEntered(other);
    }

    protected void OnTriggerCollisionExited(TriggerCollision trigger, Collider other)
    {
        if (!IsRegistered(other)) return;
        trigger.InvokeEventExited(other);
    }

    public void Register(Collider collider)
    {
        CollidersRegistered.Add(collider);
    }
    public void Unregister(Collider collider)
    {
        CollidersRegistered.Remove(collider);
    }

    public bool IsRegistered(Collider collider)
    {
        return CollidersRegistered.Contains(collider);
    }
}
