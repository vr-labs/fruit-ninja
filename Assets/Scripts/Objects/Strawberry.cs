using UnityEngine;

public class Strawberry : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Strawberry;
    
    public override Vector3 GetSize()
    {
        return new Vector3(12f, 12f, 12f);
    }
}
