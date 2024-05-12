using UnityEngine;

public class Strawberry : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Strawberry;
    
    public override Vector3 GetSize()
    {
        return new Vector3(30f, 30f, 30f);
    }
}
