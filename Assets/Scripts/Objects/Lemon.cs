using UnityEngine;

public class Lemon : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Lemon;
    
    public override Vector3 GetSize()
    {
        return new Vector3(30f, 30f, 30f);
    }
}
