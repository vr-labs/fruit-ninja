using UnityEngine;

public class Peach : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Peach;
    
    public override Vector3 GetSize()
    {
        return new Vector3(30f, 30f, 30f);
    }
}
