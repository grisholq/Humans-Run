using UnityEngine;
using System;
using System.Collections.Generic;

public class Pool<T> : Singleton<Pool<T>> where T : MonoBehaviour
{
    [SerializeField] private T _prefab;

    public event Action<T> RetrievedFromPool;
    public event Action<T> ReturnedToPool;

    private Stack<T> _pool;

    private void Awake()
    {
        _pool = new Stack<T>();
    }

    public T Retrieve()
    {
        T instance = Get();
        Enable(instance);
        if (RetrievedFromPool != null) RetrievedFromPool(instance);
        return instance;
    }

    public void Return(T instance)
    {       
        _pool.Push(instance);
        Disable(instance);
        if (ReturnedToPool != null) ReturnedToPool(instance);
    }

    private T Get()
    {
        if (_pool.Empty())
        {
            return Instantiate(_prefab);
        }

        return _pool.Pop();
    }

    private void Disable(T instance)
    {
        instance.gameObject.SetActive(false);
        instance.transform.SetParent(transform);
    }

    private void Enable(T instance)
    {
        instance.gameObject.SetActive(true);
    }
}