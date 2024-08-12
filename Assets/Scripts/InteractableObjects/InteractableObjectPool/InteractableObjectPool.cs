using Assets.Scripts.InteractableObjects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class InteractableObjectPool<T> : MonoBehaviour where T : InteractableObject
{
    [SerializeField] private T _prefab;
    [SerializeField] private bool _isChekCollection = true;
    [SerializeField, Min(1)] private int _capacity;
    [SerializeField, Min(1)] private int _maxSize;

    protected ObjectPool<T> Pool;
    private List<T> _activeObjects;

    protected virtual void Awake()
    {
        Pool = new ObjectPool<T>(
           createFunc: () => CreateFunc(),
           actionOnGet: (obj) => ActionOnGet(obj),
           actionOnRelease: (obj) => ActionOnRelease(obj),
           actionOnDestroy: (obj) => ActionOnDestroy(obj),
           collectionCheck: _isChekCollection,
           defaultCapacity: _capacity,
           maxSize: _maxSize
           );

        _activeObjects = new List<T>();
    }

    public T Get() => Pool.Get();

    public void ReturnActiveObjects()
    {
        var tempBjects = _activeObjects.ToArray ();

        foreach (var obj in tempBjects)
            Pool.Release(obj);        
    }

    protected virtual void ActionOnRelease(T obj)
    {
        obj.gameObject.SetActive(false);
        _activeObjects.Remove(obj);
    }

    protected virtual T CreateFunc()
    {
        T created = Instantiate(_prefab);
        created.ReadyOnReleasing += Release;
        return created;
    }

    protected virtual void ActionOnGet(T obj)
    {
        obj.gameObject.SetActive(true);
        _activeObjects.Add(obj);
    }

    protected virtual void ActionOnDestroy(T obj)
    {
        obj.ReadyOnReleasing -= Release;
        _activeObjects.Remove(obj);
        Destroy(obj.gameObject);
    }

    protected virtual void Release(InteractableObject obj)
    {
        var releaseObj = obj as T;

        if (releaseObj != null)
        {
            Pool.Release(releaseObj);
        }
    }
}