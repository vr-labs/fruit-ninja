using UnityEngine;

public class Watermelon : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Watermelon;
    
    public override Vector3 GetSize()
    {
        return new Vector3(30f, 30f, 30f);
    }
}
