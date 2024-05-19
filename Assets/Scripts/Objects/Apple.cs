using UnityEngine;

public class Apple : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Apple;
    public override Vector3 GetSize()
    {
        return new Vector3(18f, 18f, 18f);
    }
}
