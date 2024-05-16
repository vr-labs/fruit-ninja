using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class FlyingObjectBase: MonoBehaviour, IFlyingObject
{
    public abstract FlyingObjectType Type { get; }
    public GameObject ObjectPrefab
    {
        get => prefab;
        set => prefab = value;
    }
    
    [SerializeField]
    public GameObject prefab;
    
    public void Launch()
    {
        Debug.Log("launched");
    }

    public virtual void OnHit()
    {
        GameManager.Instance.AddScore(1);
        Debug.Log(GameManager.Instance.Score);
    }

    public abstract Vector3 GetSize();
}
