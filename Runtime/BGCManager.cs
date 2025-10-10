public abstract class BGCManager<TGameManager, TGameData> : BGCBaseManager<TGameManager>
where TGameManager : BGCBaseManager<TGameData>
where TGameData : BGCGameData
{
    public TGameManager GameManager { get; set; }

    public override void Initialize(TGameManager gameManager)
    {
        GameManager = gameManager;
    }
}