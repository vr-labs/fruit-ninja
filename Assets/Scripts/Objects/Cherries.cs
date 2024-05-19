using UnityEngine;

public class Cherries : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Cherries;
    
    public override Vector3 GetSize()
    {
        return new Vector3(15f, 15f, 15f);
    }
}
