using UnityEngine;

public class InterractsManager : BGSManager, IInputInterraction
{
    public TriggerInterraction[] TriggersCollision { get; private set; }
    public TriggerInterraction CurrentInterractionAvailable { get; private set; }

    public override void Initialize(BGSGameManager gameManager)
    {
        base.Initialize(gameManager);

        TriggersCollision = FindObjectsByType<TriggerInterraction>(FindObjectsSortMode.None);

        foreach (var trigger in TriggersCollision)
        {
            trigger.ConnectTriggerInterract(OnTriggerEnterInterract, OnTriggerExitInterract);
        }
    }

    protected void OnTriggerEnterInterract(TriggerInterraction interraction)
    {
        CurrentInterractionAvailable = interraction;
    }

    protected void OnTriggerExitInterract(TriggerInterraction _)
    {
        CurrentInterractionAvailable = null;
    }

    public void InterractionPressed()
    {
        CurrentInterractionAvailable?.Interract();
    }
}
