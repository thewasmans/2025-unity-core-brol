public abstract class BGCManager<TGameManager, TGameData> : BGCBaseManager<TGameManager>
where TGameManager : BGCGameManager<TGameData>
where TGameData : BGCGameData
{
    public TGameManager GameManager { get; set; }
    public TGameData GameData => GameManager.GameData;

    public override void Initialize(TGameManager gameManager)
    {
        GameManager = gameManager;
    }
}