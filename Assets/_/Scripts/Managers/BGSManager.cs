public class BGSManager : BaseManager<GameManager>
{
    public GameManager GameManager;
    
    public override void Initialize(GameManager gameManager)
    {
        GameManager = gameManager;
    }
}