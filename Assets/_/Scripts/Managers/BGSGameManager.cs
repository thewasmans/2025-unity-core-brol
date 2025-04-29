using System;
using System.Collections.Generic;
using UnityEngine;

public class BGSGameManager : BaseManager<GameData>
{
    [field: SerializeField] public GameData GameData { get; private set; }
    [field: SerializeField] public GameState GameState { get; private set; }
    [field: SerializeField] public BGSManager[] Managers { get; private set; }
    public Dictionary<Type, BGSManager> ManagersInstances { get; private set; } = new();

    public override void Initialize(GameData gameData)
    {
        if (gameData)
            GameData = gameData;

        if (!GameData)
            throw new BGSException($"{nameof(BGSGameManager)} No {nameof(GameData)} refered. The {nameof(BGSGameManager)} need a {nameof(GameData)}");

        ManagersInstances = GetInstanceManagers();

        GameState = new GameState();

        foreach (var manager in Managers)
        {
            manager.Initialize(this);
        }
    }

    void Awake()
    {
        Initialize(null);
    }

    protected Dictionary<Type, BGSManager> GetInstanceManagers()
    {
        Dictionary<Type, BGSManager> instances = new();
        foreach (var manager in Managers)
        {
            if (!instances.TryAdd(manager.GetType(), manager))
            {
                throw new BGSException($"[ {nameof(BGSGameManager)} ] The {manager.GetType()} is referenced multiple times in {Managers} when it should only be referenced once");
            }
        }
        return instances;
    }

    public T GetManager<T>() where T : BGSManager
    {
        if (ManagersInstances.TryGetValue(typeof(T), out var manager))
        {
            return manager is T bgsManager ? bgsManager : default;
        }
        return default;
    }
}