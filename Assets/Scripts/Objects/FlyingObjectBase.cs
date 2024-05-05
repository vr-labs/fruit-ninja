using UnityEngine;
using UnityEngine.Serialization;

public abstract class FlyingObjectBase: MonoBehaviour, IFlyingObject
{
    public abstract FlyingObjectType Type { get; }
    public GameObject ObjectPrefab
    {
        get => _prefab;
        set => _prefab = value;
    }
    
    [SerializeField]
    private GameObject _prefab;
    
    public void Launch()
    {
        Debug.Log("launched");
    }

    public void OnHit()
    {
        throw new System.NotImplementedException();
    }
}
