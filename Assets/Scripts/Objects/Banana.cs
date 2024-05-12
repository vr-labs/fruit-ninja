using UnityEngine;

public class Banana : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Banana;
    
    public override Vector3 GetSize()
    {
        return new Vector3(30f, 30f, 30f);
    }
}
