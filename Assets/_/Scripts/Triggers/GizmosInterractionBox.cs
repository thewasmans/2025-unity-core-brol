using UnityEngine;

public class GizmosInterractionBox : MonoBehaviour
{
    [field: SerializeField] public TriggerCollision TriggerCollision { get; private set; }
    void OnDrawGizmos()
    {
        if (!(TriggerCollision && TriggerCollision.Collider)) return;
        if (TriggerCollision.Collider is not BoxCollider box) return;
        Gizmos.color = new Color(144.0f, .0f, 71.0f / 255);
        Matrix4x4 oldMatrix = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        Gizmos.DrawCube(box.center, box.size * .5f);
        Gizmos.matrix = oldMatrix; 
    }
}