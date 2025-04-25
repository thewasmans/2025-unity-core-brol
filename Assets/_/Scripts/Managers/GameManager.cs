using System;
using UnityEngine;

public class GameManager : BaseManager<GameData>
{
    public GameData GameData;
    public GameState GameState;

    [SerializeField] public BGSManager[] BGSManagers;

    public override void Initialize(GameData gameData)
    {
        if (gameData)
            GameData = gameData;

        if (!GameData)
            throw new Exception($"{nameof(GameManager)} need a gamedata");

        foreach (var manager in BGSManagers)
        {
            manager.Initialize(this);
        }
    }

    void Awake()
    {
        Initialize(null);
    }
}