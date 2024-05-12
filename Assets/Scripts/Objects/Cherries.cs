using UnityEngine;

public class Cherries : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Cherries;
    
    public override Vector3 GetSize()
    {
        return new Vector3(30f, 30f, 30f);
    }
}
