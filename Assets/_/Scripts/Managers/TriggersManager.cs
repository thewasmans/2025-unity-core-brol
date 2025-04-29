using System.Collections.Generic;
using UnityEngine;

public class TriggersManager : BGSManager
{
    public TriggerCollision[] TriggersCollision { get; private set; }
    public HashSet<Collider> ColliderRegistered { get; private set; } = new();

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
        ColliderRegistered.Add(collider);
    }
    public void Unregister(Collider collider)
    {
        ColliderRegistered.Remove(collider);
    }

    public bool IsRegistered(Collider collider)
    {
        return ColliderRegistered.Contains(collider);
    }
}
