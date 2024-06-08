using UnityEngine;

public interface IFlyingObject
{
    FlyingObjectType Type { get; }
    float AppearingChance { get; }
    GameObject ObjectPrefab { get; set; }
    void Launch();
    void OnHit();
    Vector3 GetSize();
}
