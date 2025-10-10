using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BGCGameManager<T> : BGCBaseManager<T> where T : BGCGameData
{
    [field: SerializeField] public T GameData { get; private set; }
    [field: SerializeField] public BGCBaseManager<BGCGameManager<T>>[] Managers { get; private set; }
    public Dictionary<Type, BGCManager<BGCGameManager<T>, T>> _managersInstances { get; set; } = new();

    public override void Initialize(T gameData)
    {
        if (gameData)
            GameData = gameData;

        if (!GameData)
            throw new BGCException($"{nameof(BGCGameManager<T>)} No {nameof(GameData)} refered. The {nameof(BGCGameManager<T>)} need a {nameof(BGCGameData)}");


        _managersInstances = RetrieveInstancesManager();

        foreach (var manager in Managers)
        {
            manager.Initialize(this);
        }
    }

    protected Dictionary<Type, BGCManager<BGCGameManager<T>, T>> RetrieveInstancesManager()
    {
        Dictionary<Type, BGCManager<BGCGameManager<T>, T>> instances = new();
        foreach (var manager in Managers)
        {
            if (!instances.TryAdd(manager.GetType(), manager as BGCManager<BGCGameManager<T>, T>))
            {
                throw new BGCException($"[ {nameof(BGCGameManager<T>)} ] The {manager.GetType()} is referenced multiple times in {Managers} when it should only be referenced once");
            }
        }
        return instances;
    }

    public TManager GetManager<TManager>() where TManager : BGCManager<BGCGameManager<T>, T>
    {
        if (_managersInstances.TryGetValue(typeof(TManager), out var manager))
        {
            return manager is TManager bgsManager ? bgsManager : default;
        }
        return default;
    }
}