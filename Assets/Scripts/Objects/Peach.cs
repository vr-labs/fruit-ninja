using UnityEngine;

public class Peach : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Peach;
    
    public override Vector3 GetSize()
    {
        return new Vector3(12f, 12f, 12f);
    }
}
