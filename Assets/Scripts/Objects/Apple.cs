using UnityEngine;

public class Apple : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Apple;
    public override Vector3 GetSize()
    {
        return new Vector3(30f, 30f, 30f);
    }
}
