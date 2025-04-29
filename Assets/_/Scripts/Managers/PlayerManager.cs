using UnityEngine;

public class PlayerManager : BGSManager
{
    public Collider _collider;
    
    public override void Initialize(BGSGameManager gameManager)
    {
        base.Initialize(gameManager);
        gameManager.GetManager<TriggersManager>().Register(_collider);
    }
}
