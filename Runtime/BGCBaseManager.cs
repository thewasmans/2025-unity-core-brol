using UnityEngine;

public abstract class BGCBaseManager<T> : MonoBehaviour
{
    public abstract void Initialize(T data);
}