using UnityEngine;

public class GizmosTriggerBox : MonoBehaviour
{
    [field: SerializeField] public TriggerCollision TriggerCollision { get; private set; }
    void OnDrawGizmos()
    {
        if (!(TriggerCollision && TriggerCollision.Collider)) return;
        if (TriggerCollision.Collider is not BoxCollider box) return;
        Gizmos.color = new Color(0, .5f, 0, .5f);
        Matrix4x4 oldMatrix = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        Gizmos.DrawCube(box.center, box.size);
        Gizmos.matrix = oldMatrix;
    }
}
