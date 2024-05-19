using UnityEngine;

public class Peanut : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Peanut;
    
    public override Vector3 GetSize()
    {
        return new Vector3(15f, 15f, 15f);
    }
}
