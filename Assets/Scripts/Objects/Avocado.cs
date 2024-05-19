
using UnityEngine;

public class Avocado : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Avocado;
    
    public override Vector3 GetSize()
    {
        return new Vector3(12f, 12f, 12f);
    }
}
