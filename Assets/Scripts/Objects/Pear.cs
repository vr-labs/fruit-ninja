using UnityEngine;

public class Pear : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Pear;
    
    public override Vector3 GetSize()
    {
        return new Vector3(30f, 30f, 30f);
    }
}
