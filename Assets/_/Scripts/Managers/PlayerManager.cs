using UnityEngine;

public class PlayerManager : BGSManager
{
    [field: SerializeField] public Collider PlayerCharacterCollider { get; private set; }

    public override void Initialize(BGSGameManager gameManager)
    {
        base.Initialize(gameManager);

        if (PlayerCharacterCollider == null)
        {
            throw new System.Exception($"{nameof(PlayerCharacterCollider)} should be referenced the collider of the player character.");
        }

        gameManager.GetManager<TriggersManager>().Register(PlayerCharacterCollider);
    }
}
