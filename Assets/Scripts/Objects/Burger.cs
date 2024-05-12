using UnityEngine;

public class Burger : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Burger;
    
    public override Vector3 GetSize()
    {
        return Vector3.one;
    }
}
