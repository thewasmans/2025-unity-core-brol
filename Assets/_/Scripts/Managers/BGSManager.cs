public class BGSManager : BaseManager<BGSGameManager>
{
    public BGSGameManager GameManager { get; private set; }

    public override void Initialize(BGSGameManager gameManager)
    {
        GameManager = gameManager;
    }
}