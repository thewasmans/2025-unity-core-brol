using UnityEngine;

public class GizmosInterractionSphere : MonoBehaviour
{
    [field: SerializeField] public TriggerCollision TriggerCollision { get; private set; }
    void OnDrawGizmos()
    {
        if (!(TriggerCollision && TriggerCollision.Collider)) return;
        if (TriggerCollision.Collider is not SphereCollider sphere) return;
        Gizmos.color = new Color(144.0f, .0f, 71.0f / 255);
        Gizmos.DrawSphere(transform.position + sphere.center, sphere.radius * .5f);
    }
}