using UnityEngine;

public class GizmosTriggerSphere : MonoBehaviour
{
    [field: SerializeField] public TriggerCollision TriggerCollision { get; private set; }
    void OnDrawGizmos()
    {
        if (!(TriggerCollision && TriggerCollision.Collider)) return;
        if (TriggerCollision.Collider is not SphereCollider sphere) return;
        Gizmos.color = new Color(0, .5f, 0, .5f);
        Gizmos.DrawSphere(transform.position + sphere.center, sphere.radius);
    }
}
