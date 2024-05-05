using UnityEngine;

public interface IFlyingObject
{
    FlyingObjectType Type { get; }
    GameObject ObjectPrefab { get; set; }
    void Launch();
    void OnHit();
}
