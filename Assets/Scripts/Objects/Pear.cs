using UnityEngine;

public class Pear : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Pear;
    
    public override Vector3 GetSize()
    {
        return new Vector3(12f, 12f, 12f);
    }
}
