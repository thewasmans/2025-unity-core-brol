using UnityEngine;

public abstract class BaseManager<T> : MonoBehaviour
{
    public abstract void Initialize(T data);
}