using UnityEngine;

public class Watermelon : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Watermelon;
    public override float AppearingChance => 0.071f;


    public override Vector3 GetSize()
    {
        return new Vector3(20f, 20f, 20f);
    }
}
