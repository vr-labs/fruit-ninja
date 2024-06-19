using UnityEngine;

public class Banana : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Banana;
    public override float AppearingChance => 0.071f;


    public override Vector3 GetSize()
    {
        return new Vector3(20f, 20f, 20f);
    }
}
